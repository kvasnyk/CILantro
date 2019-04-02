using CILantroToolsWebAPI.BindingModels.Tests;
using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.DbModels;
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
                .Where(path => !path.Contains(@"\obj\"))
                .OrderBy(path => Path.GetFileNameWithoutExtension(path));

            var testCandidates = testExecs.Select(testExecPath => new TestCandidate
            {
                Name = Path.GetFileNameWithoutExtension(testExecPath),
                Path = _paths.Tests.GetSimilarPath(testExecPath).Relative
            })
            .Where(tc => !existingTests.Any(et => et.Name == tc.Name && et.Path == tc.Path));

            return testCandidates;
        }

        public async Task<Guid> CreateTestFromCandidateAsync(CreateTestFromCandidateBindingModel model)
        {
            var testCandidates = await FindTestCandidatesAsync();
            var testCandidate = testCandidates.SingleOrDefault(tc => tc.Name == model.TestCandidateName && tc.Path == model.TestCandidatePath);

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
            var testReadModel = _testsRepository.Read<TestReadModel>().Single(t => t.Id == testId);

            var generateExeOutputPath = _paths.TestsData.GenerateExeOutputs[testReadModel.Name].MainOutputPaths.Absolute;

            var result = new TestInfo
            {
                Test = testReadModel,
                MainIlSource = await _testsHelper.ReadIlSource(testReadModel.Name),
                MainIlSourcePath = _paths.TestsData.IlSources[testReadModel.Name].MainIlSourcePaths.Relative,
                ExePath = _paths.TestsData.Execs[testReadModel.Name].MainExePaths.Relative,
                GenerateExeOutput = await File.ReadAllTextAsync(generateExeOutputPath)
            };

            return result;
        }

        public async Task<SearchResult<TestReadModel>> SearchTestsAsync(SearchParameter searchParameter)
        {
            var searchResult = await _testsRepository.Search<TestReadModel>(searchParameter);
            return searchResult;
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

        public async Task GenerateIlSources(Guid testId)
        {
            var testReadModel = _testsRepository.Read<TestReadModel>().Single(t => t.Id == testId);

            var testExePath = _paths.Tests.GetDeepestPath(testReadModel.Path).Absolute;
            var testMainIlSourcePath = _paths.TestsData.IlSources[testReadModel.Name].MainIlSourcePaths.Absolute;

            var ildasmArguments = $"\"{testExePath}\" /output=\"{testMainIlSourcePath}\"";
            var ildasmProcessStartInfo = new ProcessStartInfo(_paths.Ildasm, ildasmArguments)
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };

            var ildasmProcess = Process.Start(ildasmProcessStartInfo);
            ildasmProcess.WaitForExit();

            await _testsRepository.UpdateAsync(t => t.Id == testId, t =>
            {
                t.HasIlSources = true;
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
            var output = await process.StandardOutput.ReadToEndAsync();

            return output;
        }

        public async Task AddTestInputOutputExample(Guid testId, AddTestInputOutputExampleBindingModel model)
        {
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

        private void EnsureDirectoryExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}