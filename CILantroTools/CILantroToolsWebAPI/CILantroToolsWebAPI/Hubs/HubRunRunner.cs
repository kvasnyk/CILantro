﻿using CILantroToolsWebAPI.Db;
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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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
                await _testsHelper.CompleteTestReadModel(test);
            }

            _processingRunData.CurrentTestIntId = test.IntId;
            _processingRunData.CurrentTestName = test.Name;
            SendRunData();

            var currentStep = TestRunStepHelper.GetFirstStep() as TestRunStep?;
            while (currentStep.HasValue)
            {
                await ProcessTestRunStep(currentStep.Value, test, testRun);
                currentStep = TestRunStepHelper.GetNextStep(currentStep.Value);
            }

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var testRunsRepository = scope.ServiceProvider.GetRequiredService<AppKeyRepository<TestRun>>();
                await testRunsRepository.UpdateAsync(tr => tr.Id == testRun.Id, tr =>
                {
                    tr.HasBeenProcessed = true;
                });

                var runsRepository = scope.ServiceProvider.GetRequiredService<AppKeyRepository<Run>>();
                await runsRepository.UpdateAsync(r => r.Id == ProcessingRun.Id, r =>
                {
                    r.ProcessedTestsCount++;
                });
            }

            _processingRunData.CurrentTestIntId = null;
            _processingRunData.CurrentTestName = null;
            _processingRunData.ProcessedTestsCount++;
            _processingRunData.CurrentTestStepIndex = null;
            SendRunData();
        }

        private async Task ProcessTestRunStep(TestRunStep step, TestReadModel test, TestRunReadModel testRun)
        {
            _processingRunData.CurrentTestStep = step;
            _processingRunData.CurrentTestStepIndex = TestRunStepHelper.GetStepIndex(step);
            SendRunData();

            switch (step)
            {
                case TestRunStep.GenerateInputFiles:
                    await GenerateInputFiles(test, testRun);
                    return;
                case TestRunStep.GenerateExeOutputFiles:
                    await GenerateExeOutputFiles(test, testRun);
                    return;
                case TestRunStep.GenerateCilAntroOutputFiles:
                    await GenerateCilAntroOutputFiles(test, testRun);
                    return;
            }
        }

        private async Task GenerateInputFiles(TestReadModel test, TestRunReadModel testRun)
        {
            foreach (var ioExample in test.IoExamples)
            {
                var inputPath = _paths.RunsData[ProcessingRun.Id][testRun.Id].Inputs[ioExample.Name.Replace(' ', '_')].Absolute;
                await File.WriteAllTextAsync(inputPath, ioExample.Input);
            }
        }

        private async Task GenerateExeOutputFiles(TestReadModel test, TestRunReadModel testRun)
        {
            var testExePath = _paths.TestsData.Execs[test.Name].MainExePaths.Absolute;
            var inputsPath = _paths.RunsData[ProcessingRun.Id][testRun.Id].Inputs;

            foreach (var inputFile in Directory.GetFiles(inputsPath.Absolute))
            {
                var outputPath = _paths.RunsData[ProcessingRun.Id][testRun.Id].Outputs[Path.GetFileNameWithoutExtension(inputFile)].Absolute;

                var processStartInfo = new ProcessStartInfo(testExePath)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                };

                var newProcess = Process.Start(processStartInfo);

                using (var streamReader = new StreamReader(inputFile))
                {
                    await newProcess.StandardInput.WriteAsync(await streamReader.ReadToEndAsync());
                    await newProcess.StandardInput.FlushAsync();
                }

                var outputBuilder = new StringBuilder();

                var exeOutput = newProcess.StandardOutput;
                while (!exeOutput.EndOfStream)
                {
                    var outputLine = await exeOutput.ReadLineAsync();
                    outputBuilder.AppendLine(outputLine);
                }

                await File.WriteAllTextAsync(outputPath, outputBuilder.ToString());
            }
        }

        private async Task GenerateCilAntroOutputFiles(TestReadModel test, TestRunReadModel testRun)
        {
            var testExePath = _paths.TestsData.Execs[test.Name].MainExePaths.Absolute;
            var inputsPath = _paths.RunsData[ProcessingRun.Id][testRun.Id].Inputs;

            foreach (var inputFile in Directory.GetFiles(inputsPath.Absolute))
            {
                var outputPath = _paths.RunsData[ProcessingRun.Id][testRun.Id].CilAntroOutputs[Path.GetFileNameWithoutExtension(inputFile)].Absolute;

                var processStartInfo = new ProcessStartInfo(_paths.CilAntro, $"--fileName \"{test.MainIlSourcePathFull}\"")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                };

                var newProcess = Process.Start(processStartInfo);

                using (var streamReader = new StreamReader(inputFile))
                {
                    await newProcess.StandardInput.WriteAsync(await streamReader.ReadToEndAsync());
                    await newProcess.StandardInput.FlushAsync();
                }

                var outputBuilder = new StringBuilder();

                var exeOutput = newProcess.StandardOutput;
                while (!exeOutput.EndOfStream)
                {
                    var outputLine = await exeOutput.ReadLineAsync();
                    outputBuilder.AppendLine(outputLine);
                }

                await File.WriteAllTextAsync(outputPath, outputBuilder.ToString());
            }
        }

        private void SendRunData(Action continueWith = null)
        {
            if (_processingStartedOn.HasValue && _processingFinishedOn.HasValue)
                _processingRunData.ProcessedForSeconds = (int?)(_processingFinishedOn - _processingStartedOn).Value.TotalSeconds;
            else if (_processingStartedOn.HasValue)
                _processingRunData.ProcessedForSeconds = (int?)(DateTime.Now - _processingStartedOn).Value.TotalSeconds;

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