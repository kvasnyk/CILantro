using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.Enums;
using CILantroToolsWebAPI.Exceptions;
using CILantroToolsWebAPI.Models.Runs;
using CILantroToolsWebAPI.ReadModels.Runs;
using CILantroToolsWebAPI.ReadModels.Tests;
using CILantroToolsWebAPI.Utils;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Hubs
{
    public class HubRunRunner
    {
        private IServiceScopeFactory _serviceScopeFactory;

        private IHubContext<RunningRunHub> _hubContext;

        private readonly Paths _paths;

        private readonly TestsHelper _testsHelper;

        private Task _processingTask;

        private RunData _processingRunData;

        private DateTime? _processingStartedOn;

        private DateTime? _processingFinishedOn;

        public RunReadModel ProcessingRun;

        public HubRunRunner(
            Paths paths,
            TestsHelper testsHelper,
            IServiceScopeFactory serviceScopeFactory,
            IHubContext<RunningRunHub> hubContext
        )
        {
            _paths = paths;
            _testsHelper = testsHelper;
            _serviceScopeFactory = serviceScopeFactory;
            _hubContext = hubContext;
        }

        public async void Run(Guid runId)
        {
            if (_processingTask != null)
                await CancelExistingRun();

            _processingTask = Task.Run(async () =>
            {
                _processingStartedOn = DateTime.Now;

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var runsRepository = scope.ServiceProvider.GetRequiredService<AppKeyRepository<Run>>();

                    ProcessingRun = runsRepository.Read<RunReadModel>().SingleOrDefault(r => r.Id == runId);
                    _processingRunData = new RunData(ProcessingRun);

                    if (ProcessingRun == null)
                        throw new ToolsException($"Cannot find run with id {runId}.");
                }

                await SaveRunData();

                foreach (var testRun in ProcessingRun.TestRuns)
                {
                    await ProcessTestRun(testRun);
                }

                _processingFinishedOn = DateTime.Now;
                _processingRunData.Status = RunStatus.Finished;

                await SaveRunData();
                SendRunData(() =>
                {
                    ProcessingRun = null;
                    _processingRunData = null;
                    _processingTask = null;
                    _processingStartedOn = null;
                    _processingFinishedOn = null;
                });
            });
        }

        public async Task CancelExistingRun()
        {
            if (ProcessingRun != null)
            {
                if (_processingTask != null)
                {
                    _processingTask.Dispose();
                }

                _processingRunData.Status = RunStatus.Cancelled;
                await SaveRunData();
                
                ProcessingRun = null;
                _processingRunData = null;
                _processingTask = null;
                _processingStartedOn = null;
                _processingFinishedOn = null;
            }
        }

        private async Task ProcessTestRun(TestRunReadModel testRun)
        {
            TestReadModel test;
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var testsRepository = scope.ServiceProvider.GetRequiredService<AppKeyRepository<Test>>();
                test = testsRepository.Read<TestReadModel>().SingleOrDefault(t => t.Id == testRun.TestId);
            }

            _processingRunData.CurrentTestName = test.Name;
            SendRunData();

            var currentStep = TestRunStepHelper.GetFirstStep() as TestRunStep?;
            var testRunOutcome = RunOutcome.Ok;
            while (currentStep.HasValue)
            {
                var stepOutcome = await ProcessTestRunStep(currentStep.Value, test, testRun);
                currentStep = TestRunStepHelper.GetNextStep(currentStep.Value);

                testRunOutcome = testRunOutcome == RunOutcome.Ok && stepOutcome == RunOutcome.Ok ? RunOutcome.Ok : RunOutcome.Wrong;
            }

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var testRunsRepository = scope.ServiceProvider.GetRequiredService<AppKeyRepository<TestRun>>();
                await testRunsRepository.UpdateAsync(tr => tr.Id == testRun.Id, tr =>
                {
                    tr.HasBeenProcessed = true;
                    tr.Outcome = testRunOutcome;
                });

                var runsRepository = scope.ServiceProvider.GetRequiredService<AppKeyRepository<Run>>();
                await runsRepository.UpdateAsync(r => r.Id == ProcessingRun.Id, r =>
                {
                    var newOutcome = r.Outcome == RunOutcome.Ok && testRunOutcome == RunOutcome.Ok ? RunOutcome.Ok : RunOutcome.Wrong;

                    r.ProcessedTestsCount++;
                    r.Outcome = newOutcome;

                    _processingRunData.Outcome = newOutcome;
                });
            }

            _processingRunData.CurrentTestName = null;
            _processingRunData.ProcessedTestsCount++;
            _processingRunData.CurrentTestStepIndex = null;
            SendRunData();
        }

        private async Task<RunOutcome> ProcessTestRunStep(TestRunStep step, TestReadModel test, TestRunReadModel testRun)
        {
            _processingRunData.CurrentTestStep = step;
            _processingRunData.CurrentTestStepIndex = TestRunStepHelper.GetStepIndex(step);
            SendRunData();

            var started = DateTime.Now;

            var items = new List<TestRunStepItem>();

            switch (step)
            {
                case TestRunStep.GenerateInputFiles:
                    items = await GenerateInputFiles(test, testRun);
                    break;
                case TestRunStep.GenerateExeOutputFiles:
                    items = await GenerateExeOutputFiles(test, testRun);
                    break;
                case TestRunStep.GenerateCilAntroOutputFiles:
                    items = await GenerateCilAntroOutputFiles(test, testRun);
                    break;
                case TestRunStep.CompareOutputFiles:
                    items = await CompareOutputs(test, testRun);
                    break;
            }

            _processingRunData.CurrentItemIndex = null;
            _processingRunData.CurrentItemName = null;
            SendRunData();

            var finished = DateTime.Now;

            var outcome = items.All(i => i.Outcome == RunOutcome.Ok) ? RunOutcome.Ok : RunOutcome.Wrong;

            var newStepInfo = new TestRunStepInfo
            {
                Id = Guid.NewGuid(),
                ProcessedForMilliseconds = (int)(finished - started).TotalMilliseconds,
                Step = step,
                TestRunId = testRun.Id,
                Items = items,
                Outcome = outcome
            };

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var stepsRepository = scope.ServiceProvider.GetRequiredService<AppKeyRepository<TestRunStepInfo>>();
                await stepsRepository.CreateAsync(newStepInfo);
            }

            return outcome;
        }

        private async Task<List<TestRunStepItem>> GenerateInputFiles(TestReadModel test, TestRunReadModel testRun)
        {
            var result = new List<TestRunStepItem>();

            _processingRunData.AllItemsCount = ProcessingRun.Type == RunType.Quick ? test.IoExamples.Count + 3 : test.IoExamples.Count + 100;
            _processingRunData.CurrentItemIndex = 0;

            foreach (var ioExample in test.IoExamples)
            {
                var started = DateTime.Now;

                var inputName = ioExample.Name.Replace(' ', '_');

                _processingRunData.CurrentItemName = inputName;
                SendRunData();

                var inputPath = _paths.RunsData[ProcessingRun.Id][testRun.Id].Inputs[inputName].Absolute;
                await File.WriteAllTextAsync(inputPath, ioExample.Input);

                var finished = DateTime.Now;

                var item = new TestRunStepItem
                {
                    Id = Guid.NewGuid(),
                    Name = Path.GetFileNameWithoutExtension(inputPath),
                    ProcessedForMilliseconds = (int)(finished - started).TotalMilliseconds,
                    Outcome = RunOutcome.Ok
                };
                result.Add(item);

                _processingRunData.CurrentItemIndex++;
            }

            var randomInputsToGenerate = ProcessingRun.Type == RunType.Full ? 100 : 3;

            {
                var inputFactory = new InputFactory(test.Input);

                for (int i = 1; i <= randomInputsToGenerate; i++)
                {
                    var started = DateTime.Now;

                    var inputName = $"Random_{i.ToString("D3")}";

                    _processingRunData.CurrentItemName = inputName;
                    SendRunData();

                    var inputPath = _paths.RunsData[ProcessingRun.Id][testRun.Id].Inputs[inputName].Absolute;
                    var input = inputFactory.GenerateRandomInput();

                    if (input != null)
                        await File.WriteAllTextAsync(inputPath, input);

                    var finished = DateTime.Now;

                    var item = new TestRunStepItem
                    {
                        Id = Guid.NewGuid(),
                        Name = Path.GetFileNameWithoutExtension(inputPath),
                        ProcessedForMilliseconds = (int)(finished - started).TotalMilliseconds,
                        Outcome = input != null ? RunOutcome.Ok : RunOutcome.Wrong
                    };
                    result.Add(item);

                    _processingRunData.CurrentItemIndex++;
                }
            }

            return result;
        }

        private async Task<List<TestRunStepItem>> GenerateExeOutputFiles(TestReadModel test, TestRunReadModel testRun)
        {
            _processingRunData.CurrentItemIndex = 0;

            var result = new List<TestRunStepItem>();

            var testExePath = _paths.TestsData.Execs[test.Name].MainExePaths.Absolute;
            var inputsPath = _paths.RunsData[ProcessingRun.Id][testRun.Id].Inputs;

            foreach (var inputFile in Directory.GetFiles(inputsPath.Absolute))
            {
                var started = DateTime.Now;

                var inputName = Path.GetFileNameWithoutExtension(inputFile);

                _processingRunData.CurrentItemName = inputName;
                SendRunData();

                var outputPath = _paths.RunsData[ProcessingRun.Id][testRun.Id].Outputs[inputName].Absolute;
                var errorPath = _paths.RunsData[ProcessingRun.Id][testRun.Id].Errors[inputName].Absolute;

                var processStartInfo = new ProcessStartInfo(testExePath)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                };

                var newProcess = Process.Start(processStartInfo);
                var outputBuilder = new StringBuilder();
                var errorBuilder = new StringBuilder();

                using (var cancelTokenSource = new CancellationTokenSource())
                {
                    var token = cancelTokenSource.Token;

                    var inputTask = Task.Run(async () =>
                    {
                        using (var streamReader = new StreamReader(inputFile))
                        {
                            await newProcess.StandardInput.WriteAsync(await streamReader.ReadToEndAsync());
                            await newProcess.StandardInput.FlushAsync();
                        }
                    }, token);

                    var errorOutputTask = Task.Run(async () =>
                    {
                        var errorOutput = newProcess.StandardError;
                        while (!errorOutput.EndOfStream)
                        {
                            var errorLine = await newProcess.StandardError.ReadLineAsync();
                            errorBuilder.AppendLine(errorLine);
                        }
                    }, token);

                    var exeOutputTask = Task.Run(async () =>
                    {
                        var exeOutput = newProcess.StandardOutput;
                        while (!exeOutput.EndOfStream)
                        {
                            var outputLine = await exeOutput.ReadLineAsync();
                            outputBuilder.AppendLine(outputLine);
                        }
                    }, token);

                    Task.WaitAny(errorOutputTask, exeOutputTask);

                    if (!newProcess.HasExited)
                    {
                        newProcess.Kill();
                    }

                    cancelTokenSource.Cancel();
                }

                var errorText = errorBuilder.ToString();
                var hasErrors = !string.IsNullOrEmpty(errorText);

                await File.WriteAllTextAsync(outputPath, outputBuilder.ToString());
                await File.WriteAllTextAsync(errorPath, errorText);

                var finished = DateTime.Now;

                var item = new TestRunStepItem
                {
                    Id = Guid.NewGuid(),
                    Name = Path.GetFileNameWithoutExtension(inputFile),
                    ProcessedForMilliseconds = (int)(finished - started).TotalMilliseconds,
                    Outcome = !hasErrors ? RunOutcome.Ok : RunOutcome.Wrong
                };
                result.Add(item);

                _processingRunData.CurrentItemIndex++;
            }

            return result;
        }

        private async Task<List<TestRunStepItem>> GenerateCilAntroOutputFiles(TestReadModel test, TestRunReadModel testRun)
        {
            var result = new List<TestRunStepItem>();

            var testExePath = _paths.TestsData.Execs[test.Name].MainExePaths.Absolute;
            var inputsPath = _paths.RunsData[ProcessingRun.Id][testRun.Id].Inputs;

            _processingRunData.CurrentItemIndex = 0;

            foreach (var inputFile in Directory.GetFiles(inputsPath.Absolute))
            {
                var started = DateTime.Now;

                var inputName = Path.GetFileNameWithoutExtension(inputFile);

                _processingRunData.CurrentItemName = inputName;
                SendRunData();

                var outputPath = _paths.RunsData[ProcessingRun.Id][testRun.Id].CilAntroOutputs[inputName].Absolute;
                var errorPath = _paths.RunsData[ProcessingRun.Id][testRun.Id].CilAntroErrors[inputName].Absolute;
                var testIlSourcePath = _paths.TestsData.IlSources[test.Name].MainIlSourcePaths.Absolute;

                var processStartInfo = new ProcessStartInfo(_paths.CilAntro, $"--fileName \"{testIlSourcePath}\"")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                };

                var newProcess = Process.Start(processStartInfo);
                var outputBuilder = new StringBuilder();
                var errorBuilder = new StringBuilder();

                using (var cancelTokenSource = new CancellationTokenSource())
                {
                    var token = cancelTokenSource.Token;

                    var inputTask = Task.Run(async () =>
                    {
                        using (var streamReader = new StreamReader(inputFile))
                        {
                            await newProcess.StandardInput.WriteAsync(await streamReader.ReadToEndAsync());
                            await newProcess.StandardInput.FlushAsync();
                        }
                    }, token);

                    var errorOutputTask = Task.Run(async () =>
                    {
                        var errorOutput = newProcess.StandardError;
                        while (!errorOutput.EndOfStream)
                        {
                            var errorLine = await newProcess.StandardError.ReadLineAsync();
                            errorBuilder.AppendLine(errorLine);
                        }
                    }, token);

                    var exeOutputTask = Task.Run(async () =>
                    {
                        var exeOutput = newProcess.StandardOutput;
                        while (!exeOutput.EndOfStream)
                        {
                            var outputLine = await exeOutput.ReadLineAsync();
                            outputBuilder.AppendLine(outputLine);
                        }
                    }, token);

                    Task.WaitAny(errorOutputTask, exeOutputTask);

                    if (!newProcess.HasExited)
                    {
                        newProcess.Kill();
                    }

                    cancelTokenSource.Cancel();
                }

                var errorText = errorBuilder.ToString();
                var hasErrors = !string.IsNullOrEmpty(errorText);

                await File.WriteAllTextAsync(outputPath, outputBuilder.ToString());
                await File.WriteAllTextAsync(errorPath, errorText);

                var finished = DateTime.Now;

                var item = new TestRunStepItem
                {
                    Id = Guid.NewGuid(),
                    Name = Path.GetFileNameWithoutExtension(inputFile),
                    ProcessedForMilliseconds = (int)(finished - started).TotalMilliseconds,
                    Outcome = !hasErrors ? RunOutcome.Ok : RunOutcome.Wrong
                };
                result.Add(item);

                _processingRunData.CurrentItemIndex++;
            }

            return result;
        }

        private async Task<List<TestRunStepItem>> CompareOutputs(TestReadModel test, TestRunReadModel testRun)
        {
            var result = new List<TestRunStepItem>();

            var testExePath = _paths.TestsData.Execs[test.Name].MainExePaths.Absolute;
            var inputsPath = _paths.RunsData[ProcessingRun.Id][testRun.Id].Inputs;

            _processingRunData.CurrentItemIndex = 0;

            foreach (var inputFile in Directory.GetFiles(inputsPath.Absolute))
            {
                var started = DateTime.Now;

                var inputName = Path.GetFileNameWithoutExtension(inputFile);

                _processingRunData.CurrentItemName = inputName;
                SendRunData();

                var exeOutputPath = _paths.RunsData[ProcessingRun.Id][testRun.Id].Outputs[inputName].Absolute;
                var cilantroOutputPath = _paths.RunsData[ProcessingRun.Id][testRun.Id].CilAntroOutputs[Path.GetFileNameWithoutExtension(inputFile)].Absolute;

                var exeOutput = await File.ReadAllTextAsync(exeOutputPath);
                var cilantroOutput = await File.ReadAllTextAsync(cilantroOutputPath);

                var areOutputsIdentical = exeOutput.Equals(cilantroOutput);

                var finished = DateTime.Now;

                var item = new TestRunStepItem
                {
                    Id = Guid.NewGuid(),
                    Name = Path.GetFileNameWithoutExtension(inputFile),
                    ProcessedForMilliseconds = (int)(finished - started).TotalMilliseconds,
                    Outcome = areOutputsIdentical ? RunOutcome.Ok : RunOutcome.Wrong
                };
                result.Add(item);

                _processingRunData.CurrentItemIndex++;
            }

            return result;
        }

        private void SendRunData(Action continueWith = null)
        {
            if (_processingStartedOn.HasValue && _processingFinishedOn.HasValue)
                _processingRunData.ProcessedForMilliseconds = (int?)(_processingFinishedOn - _processingStartedOn).Value.TotalMilliseconds;
            else if (_processingStartedOn.HasValue)
                _processingRunData.ProcessedForMilliseconds = (int?)(DateTime.Now - _processingStartedOn).Value.TotalMilliseconds;

            var task = Task.Run(() =>
            {
                _hubContext.Clients.All.SendAsync("update-run-data", _processingRunData);
            });

            if (continueWith != null)
            {
                task.ContinueWith(t => { continueWith(); });
            }
        }

        private async Task SaveRunData()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var runsRepository = scope.ServiceProvider.GetRequiredService<AppKeyRepository<Run>>();
                await runsRepository.UpdateAsync(r => r.Id == ProcessingRun.Id, r =>
                {
                    r.Status = _processingRunData.Status;
                    r.ProcessingStartedOn = _processingStartedOn;
                    r.ProcessingFinishedOn = _processingFinishedOn;
                });
            }
        }
    }
}