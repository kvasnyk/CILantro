using CILantroToolsWebAPI.BindingModels.Tests;
using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.Models.Tests;
using CILantroToolsWebAPI.ReadModels.Tests;
using CILantroToolsWebAPI.Search;
using CILantroToolsWebAPI.Settings;
using Microsoft.Extensions.Options;
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
        private const string IL_SOURCES_DIRECTORY_NAME = "il-sources";

        private const string EXECS_DIRECTORY_NAME = "execs";

        private readonly IOptions<AppSettings> _appSettings;

        private readonly AppKeyRepository<Test> _testsRepository;

        public TestsService(IOptions<AppSettings> appSettings, AppKeyRepository<Test> testsRepository)
        {
            _appSettings = appSettings;
            _testsRepository = testsRepository;

            var ilSourcesPath = BuildIlSourcesPath();
            EnsureDirectoryExists(ilSourcesPath);
        }

        public async Task<IEnumerable<TestCandidate>> FindTestCandidatesAsync()
        {
            var existingTests = _testsRepository.Read<TestReadModel>();

            var testExecs = Directory
                .GetFiles(_appSettings.Value.TestsDirectoryPath, "*.exe", SearchOption.AllDirectories)
                .Where(path => path.Contains(@"\Release\"))
                .Where(path => !path.Contains(@"\obj\"))
                .OrderBy(path => Path.GetFileNameWithoutExtension(path));

            var testCandidates = testExecs.Select(testExecPath => new TestCandidate
            {
                Name = Path.GetFileNameWithoutExtension(testExecPath),
                Path = testExecPath.Substring(_appSettings.Value.TestsDirectoryPath.Length)
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
                Path = testCandidate.Path
            };

            return await _testsRepository.CreateAsync(newTest);
        }

        public async Task<TestReadModel> GetTestAsync(Guid testId)
        {
            var result = _testsRepository.Read<TestReadModel>().Single(t => t.Id == testId);
            await CompleteTestReadModel(result);
            return result;
        }

        public async Task<SearchResult<TestReadModel>> SearchTestsAsync(SearchParameter searchParameter)
        {
            var searchResult = await _testsRepository.Search<TestReadModel>(searchParameter);
            await CompleteTestReadModels(searchResult.Data);
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

            var testExePath = BuildTestOriginalExePath(testReadModel.Path);
            var testMainIlSourcePath = BuildTestMainIlSourcePath(testReadModel.Name);

            var ildasmArguments = $"\"{testExePath}\" /output=\"{testMainIlSourcePath}\"";
            var ildasmProcessStartInfo = new ProcessStartInfo(_appSettings.Value.IldasmExePath, ildasmArguments)
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };

            var ildasmProcess = Process.Start(ildasmProcessStartInfo);
            ildasmProcess.WaitForExit();
        }

        public async Task GenerateExe(Guid testId)
        {
            var testReadModel = _testsRepository.Read<TestReadModel>().Single(t => t.Id == testId);

            var ilSourcePath = BuildTestMainIlSourcePath(testReadModel.Name);
            var exePath = BuildTestExePath(testReadModel.Name);

            var ilasmArguments = $"\"{ilSourcePath}\" /output=\"{exePath}\"";
            var ilasmProcessStartInfo = new ProcessStartInfo(_appSettings.Value.IlasmExePath, ilasmArguments)
            {
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var ilasmProcess = Process.Start(ilasmProcessStartInfo);
            ilasmProcess.WaitForExit();
        }

        private async Task CompleteTestReadModel(TestReadModel testReadModel)
        {
            var testIlSourcesPath = BuildTestIlSourcesPath(testReadModel.Name);
            EnsureDirectoryExists(testIlSourcesPath);

            var testExecsPath = BuildTestExecsPath(testReadModel.Name);
            EnsureDirectoryExists(testExecsPath);

            testReadModel.MainIlSource = await ReadIlSource(testReadModel.Name);
            if (testReadModel.HasIlSources)
            {
                testReadModel.MainIlSourcePath = BuildTestMainIlSourcePath(testReadModel.Name, true);
            }

            var testExePath = BuildTestExePath(testReadModel.Name);

            if (File.Exists(testExePath))
            {
                testReadModel.ExePath = BuildTestExePath(testReadModel.Name, true);
                testReadModel.ExePathFull = testExePath;
            }
        }

        private async Task CompleteTestReadModels(IEnumerable<TestReadModel> testReadModels)
        {
            var tasks = new List<Task>();

            foreach (var testReadModel in testReadModels)
            {
                tasks.Add(CompleteTestReadModel(testReadModel));
            }

            await Task.WhenAll(tasks);
        }

        private string BuildIlSourcesPath()
        {
            return Path.Combine(_appSettings.Value.TestsDataDirectoryPath, IL_SOURCES_DIRECTORY_NAME);
        }

        private string BuildExecsPath()
        {
            return Path.Combine(_appSettings.Value.TestsDataDirectoryPath, EXECS_DIRECTORY_NAME);
        }

        private string BuildTestOriginalExePath(string testPath)
        {
            return Path.Combine(_appSettings.Value.TestsDirectoryPath, testPath.Substring(1));
        }

        private string BuildTestIlSourcesPath(string testName)
        {
            var ilSourcesPath = BuildIlSourcesPath();
            return Path.Combine(ilSourcesPath, testName);
        }

        private string BuildTestExecsPath(string testName)
        {
            var execsPath = BuildExecsPath();
            return Path.Combine(execsPath, testName);
        }

        private string BuildTestMainIlSourcePath(string testName, bool relative = false)
        {
            var ilSourceFileName = $"{testName}.il";
            var testIlSourcesPath = BuildTestIlSourcesPath(testName);
            var ilSourcePath = Path.Combine(testIlSourcesPath, ilSourceFileName);

            if (relative) ilSourcePath = ilSourcePath.Substring(_appSettings.Value.TestsDataDirectoryPath.Length);

            return ilSourcePath;
        }

        private string BuildTestExePath(string testName, bool relative = false)
        {
            var exeFileName = $"{testName}.exe";
            var testExecsPath = BuildTestExecsPath(testName);
            var exePath = Path.Combine(testExecsPath, exeFileName);

            if (relative) exePath = exePath.Substring(_appSettings.Value.TestsDataDirectoryPath.Length);

            return exePath;
        }

        private async Task<string> ReadIlSource(string testName)
        {
            var ilSourcePath = BuildTestMainIlSourcePath(testName);

            if (!File.Exists(ilSourcePath))
            {
                return null;
            }

            return await File.ReadAllTextAsync(ilSourcePath);
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