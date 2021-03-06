﻿using CILantroToolsWebAPI.BindingModels.Tests;
using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.Enums;
using CILantroToolsWebAPI.Exceptions;
using CILantroToolsWebAPI.Models.Tests;
using CILantroToolsWebAPI.ReadModels.Tests;
using CILantroToolsWebAPI.Search;
using CILantroToolsWebAPI.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Services
{
    public class TestsService
    {
        private readonly Paths _paths;

        private readonly TestsHelper _testsHelper;

        private readonly AppKeyRepository<Test> _testsRepository;

        private readonly AppKeyRepository<TestInputOutputExample> _testIoExamplesRepository;

        public TestsService(
            Paths paths,
            TestsHelper testsHelper,
            AppKeyRepository<Test> testsRepository,
            AppKeyRepository<TestInputOutputExample> testIoExamplesRepository)
        {
            _paths = paths;
            _testsHelper = testsHelper;
            _testsRepository = testsRepository;
            _testIoExamplesRepository = testIoExamplesRepository;
        }

        public async Task<IEnumerable<TestCandidate>> FindTestCandidatesAsync()
        {
            var existingTests = _testsRepository.Read<TestReadModel>();

            var testExecs = Directory
                .GetFiles(_paths.Tests.Absolute, "*.exe", SearchOption.AllDirectories)
                .Where(path => path.Contains(@"\Release\"))
                .Where(path => !Path.GetFileName(path).Contains(".vshost"))
                .Where(path => !path.Contains(@"\obj\"))
                .OrderBy(path => Path.GetFileNameWithoutExtension(path));

            var cilTests = Directory
                .GetFiles(_paths.Tests.Absolute, "*.il", SearchOption.AllDirectories)
                .OrderBy(path => Path.GetFileNameWithoutExtension(path));

            var allTests = testExecs.Union(cilTests);

            var testCandidates = allTests.Select(testPath => new TestCandidate
            {
                Name = Path.GetFileNameWithoutExtension(testPath),
                Path = _paths.Tests.GetSimilarPath(testPath).Relative
            })
            .Where(tc => !existingTests.Any(et => et.Name == tc.Name && et.Path == tc.Path));

            return testCandidates;
        }

        public async Task<Guid> CreateTestFromCandidateAsync(CreateTestFromCandidateBindingModel model)
        {
            var testCandidates = await FindTestCandidatesAsync();
            var testCandidate = testCandidates.SingleOrDefault(tc => tc.Name == model.TestCandidateName && tc.Path == model.TestCandidatePath);

            var existingTest = _testsRepository.Read<TestReadModel>().SingleOrDefault(t => t.Name == testCandidate.Name);
            if (existingTest != null)
                throw new ToolsException("A test with the same name already exists.");

            var newTest = new Test
            {
                Id = Guid.NewGuid(),
                Name = testCandidate.Name,
                Path = testCandidate.Path,
                CreatedOn = DateTime.Now
            };

            return await _testsRepository.CreateAsync(newTest);
        }

        public async Task<TestReadModel> GetTestAsync(Guid testId)
        {
            var result = _testsRepository.Read<TestReadModel>().Single(t => t.Id == testId);
            return result;
        }

        public async Task<TestInfo> GetTestInfoAsync(Guid testId)
        {
            await _testsRepository.UpdateAsync(t => t.Id == testId, t =>
            {
                t.LastOpenedOn = DateTime.Now;
            });

            var testReadModel = _testsRepository.Read<TestReadModel>().Single(t => t.Id == testId);

            var generateExeOutputPath = _paths.TestsData.GenerateExeOutputs[testReadModel.Name].MainOutputPaths.Absolute;

            var result = new TestInfo
            {
                Test = testReadModel,
                MainIlSource = await _testsHelper.ReadIlSource(testReadModel.Name),
                MainIlSourcePath = _paths.TestsData.IlSources[testReadModel.Name].MainIlSourcePaths.Relative,
                ExePath = _paths.TestsData.Execs[testReadModel.Name].MainExePaths.Relative,
                GenerateExeOutput = File.Exists(generateExeOutputPath) ? await File.ReadAllTextAsync(generateExeOutputPath) : null
            };

            return result;
        }

        public async Task<SearchResult<TestReadModel>> SearchTestsAsync(SearchParameter searchParameter)
        {
            var searchResult = await _testsRepository.Search<TestReadModel>(searchParameter);
            return searchResult;
        }

        public async Task DisableTestAsync(Guid testId)
        {
            await _testsRepository.UpdateAsync(t => t.Id == testId, test =>
            {
                test.IsDisabled = true;
                test.DisabledReason = null;
            });
        }

        public async Task EnableTestAsync(Guid testId)
        {
            await _testsRepository.UpdateAsync(t => t.Id == testId, test =>
            {
                test.IsDisabled = false;
                test.DisabledReason = null;
            });
        }

        public async Task EditTestDisabledReasonAsync(Guid testId, EditTestDisabledReasonBindingModel model)
        {
            await _testsRepository.UpdateAsync(t => t.Id == testId, test =>
            {
                test.DisabledReason = model.DisabledReason;
            });
        }

        public async Task EditTestCategoryAsync(Guid testId, EditTestCategoryBindingModel model)
        {
            await _testsRepository.UpdateAsync(t => t.Id == testId, test =>
            {
                test.CategoryId = model.CategoryId;
                test.SubcategoryId = null;
            });
        }

        public async Task EditTestSubcategoryAsync(Guid testId, EditTestSubcategoryBindingModel model)
        {
            await _testsRepository.UpdateAsync(t => t.Id == testId, test =>
            {
                test.SubcategoryId = model.SubcategoryId;
            });
        }

        public async Task EditTestHasEmptyInputAsync(Guid testId, EditTestHasEmptyInputBindingModel model)
        {
            await _testsRepository.UpdateAsync(t => t.Id == testId, test =>
            {
                test.HasEmptyInput = model.HasEmptyInput;
            });
        }

        public async Task EditTestInputAsync(Guid testId, EditTestInputBindingModel model)
        {
            await _testsRepository.UpdateAsync(t => t.Id == testId, test =>
            {
                test.HasEmptyInput = model.HasEmptyInput;
                test.Input = model.Input;
            });
        }

        public async Task EditTestOutputAsync(Guid testId, EditTestOutputBindingModel model)
        {
            await _testsRepository.UpdateAsync(t => t.Id == testId, test =>
            {
                test.Output = model.Output;
            });
        }

        public async Task CopyTestInput(Guid testId, CopyTestInputBindingModel model)
        {
            var test = _testsRepository.Read<TestReadModel>().Single(t => t.Id == testId);
            var sourceTest = _testsRepository.Read<TestReadModel>().Single(t => t.Id == model.SourceTestId);

            await _testsRepository.UpdateAsync(t => t.Id == testId, t =>
            {
                t.HasEmptyInput = sourceTest.HasEmptyInput;
                t.Input = sourceTest.Input;
            });
        }

        public async Task GenerateIlSources(Guid testId)
        {
            var testReadModel = _testsRepository.Read<TestReadModel>().Single(t => t.Id == testId);

            _paths.TestsData.IlSources[testReadModel.Name].ClearDirectory();

            var testPath = _paths.Tests.GetDeepestPath(testReadModel.Path).Absolute;
            var testMainIlSourcePath = _paths.TestsData.IlSources[testReadModel.Name].MainIlSourcePaths.Absolute;

            if (Path.GetExtension(testPath) == ".exe")
            {
                var ildasmArguments = $"\"{testPath}\" /output=\"{testMainIlSourcePath}\"";
                var ildasmProcessStartInfo = new ProcessStartInfo(_paths.Ildasm, ildasmArguments)
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                };

                var ildasmProcess = Process.Start(ildasmProcessStartInfo);
                ildasmProcess.WaitForExit();
            }
            else if (Path.GetExtension(testPath) == ".il")
            {
                File.Copy(testPath, testMainIlSourcePath);
            }

            var testDirectoryPath = Path.GetDirectoryName(_paths.Tests.GetDeepestPath(testReadModel.Path).Absolute);
            var dlls = Directory.GetFiles(testDirectoryPath, "*.dll");
            foreach (var dll in dlls)
            {
                var newPath = Path.Combine(Path.GetDirectoryName(testMainIlSourcePath), Path.GetFileName(dll));
                File.Copy(dll, newPath);
            }

            await _testsRepository.UpdateAsync(t => t.Id == testId, t =>
            {
                t.HasIlSources = true;
                t.HasExe = false;
            });
        }

        public async Task GenerateExe(Guid testId)
        {
            var testReadModel = _testsRepository.Read<TestReadModel>().Single(t => t.Id == testId);

            _paths.TestsData.Execs[testReadModel.Name].ClearDirectory();

            var ilSourcePath = _paths.TestsData.IlSources[testReadModel.Name].MainIlSourcePaths.Absolute;
            var exePath = _paths.TestsData.Execs[testReadModel.Name].MainExePaths.Absolute;
            var outputPath = _paths.TestsData.GenerateExeOutputs[testReadModel.Name].MainOutputPaths.Absolute;

            var ilasmArguments = $"\"{ilSourcePath}\" /output=\"{exePath}\"";
            var ilasmProcessStartInfo = new ProcessStartInfo(_paths.Ilasm, ilasmArguments)
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardError = true
            };

            var ilasmProcess = Process.Start(ilasmProcessStartInfo);
            using (var reader = ilasmProcess.StandardError)
            {
                var result = await reader.ReadToEndAsync();
                File.WriteAllText(outputPath, result);
            }

            ilasmProcess.WaitForExit();

            var testDirectoryPath = Path.GetDirectoryName(_paths.Tests.GetDeepestPath(testReadModel.Path).Absolute);
            var dlls = Directory.GetFiles(testDirectoryPath, "*.dll");
            foreach (var dll in dlls)
            {
                var newPath = Path.Combine(Path.GetDirectoryName(exePath), Path.GetFileName(dll));
                File.Copy(dll, newPath);
            }

            await _testsRepository.UpdateAsync(t => t.Id == testId, t =>
            {
                t.HasExe = true;
            });
        }

        public async Task<string> GenerateOutput(Guid testId, GenerateOutputBindingModel model)
        {
            var test = await GetTestAsync(testId);

            var testExePath = _paths.TestsData.Execs[test.Name].MainExePaths.Absolute;

            var processStartInfo = new ProcessStartInfo(testExePath)
            {
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };

            var process = Process.Start(processStartInfo);

            await process.StandardInput.WriteAsync(model.Input);
            await process.StandardInput.FlushAsync();

            var output = await process.StandardOutput.ReadToEndAsync();

            if (!process.HasExited)
            {
                process.Kill();
            }

            return output;
        }

        public async Task AddTestInputOutputExample(Guid testId, AddTestInputOutputExampleBindingModel model)
        {
            var test = _testsRepository.Read<TestReadModel>().Single(t => t.Id == testId);

            if (model.IsDifficult)
                model.Name = $"Difficult {test.IoExamples.Count(ioe => ioe.Name.StartsWith("Difficult")) + 1}";

            if (string.IsNullOrEmpty(model.Name))
                throw new ToolsException("An example's name cannot be empty.");

            var exampleWithSameName = _testIoExamplesRepository.Read<TestIoExampleReadModel>().SingleOrDefault(e => e.TestId == testId && e.Name == model.Name);
            if (exampleWithSameName != null)
                throw new ToolsException("An example with the same name already exists");

            var exampleWithSameInputAndOutput = _testIoExamplesRepository.Read<TestIoExampleReadModel>()
                .SingleOrDefault(e => e.TestId == testId && e.Input == model.Input && e.Output == model.Output);
            if (exampleWithSameInputAndOutput != null)
                throw new ToolsException("An identical example already exists.");

            var newExample = new TestInputOutputExample
            {
                Id = Guid.NewGuid(),
                TestId = testId,
                Name = model.Name,
                Input = model.Input,
                Output = model.Output
            };

            await _testIoExamplesRepository.CreateAsync(newExample);
        }

        public async Task<TestsCheck> CheckTests()
        {
            return new TestsCheck
            {
                NotReadyTests = _testsRepository.Read<TestReadModel>().Count(t => !t.IsReady),
                NotRunTests = _testsRepository.Read<TestReadModel>().Count(t => !t.LastRunOutcome.HasValue),
                NotOkTests = _testsRepository.Read<TestReadModel>().Count(t => t.LastRunOutcome.HasValue && t.LastRunOutcome.Value == RunOutcome.Wrong),
                DisabledTests = _testsRepository.Read<TestReadModel>().Count(t => t.IsDisabled)
            };
        }

        private void EnsureDirectoryExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}