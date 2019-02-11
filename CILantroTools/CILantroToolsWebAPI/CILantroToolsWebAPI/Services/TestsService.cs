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
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Services
{
    public class TestsService
    {
        private const string IL_SOURCES_DIRECTORY_NAME = "il-sources";

        private readonly IOptions<AppSettings> _appSettings;

        private readonly AppKeyRepository<Test> _testsRepository;

        public TestsService(IOptions<AppSettings> appSettings, AppKeyRepository<Test> testsRepository)
        {
            _appSettings = appSettings;
            _testsRepository = testsRepository;
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

        private async Task CompleteTestReadModel(TestReadModel testReadModel)
        {
            testReadModel.MainIlSource = await ReadIlSource(testReadModel.Name);
        }

        private async Task CompleteTestReadModels(IEnumerable<TestReadModel> testReadModels)
        {
            foreach (var testReadModel in testReadModels)
            {
                await CompleteTestReadModel(testReadModel);
            }
        }

        private string BuildIlSourcesPath()
        {
            return Path.Combine(_appSettings.Value.TestsDataDirectoryPath, IL_SOURCES_DIRECTORY_NAME);
        }

        private string BuildMainIlSourcePath(string testName)
        {
            var ilSourceFileName = $"{testName}.il";
            var ilSourcesPath = BuildIlSourcesPath();
            var ilSourcePath = Path.Combine(ilSourcesPath, testName, ilSourceFileName);
            return ilSourcePath;
        }

        private async Task<string> ReadIlSource(string testName)
        {
            var ilSourcePath = BuildMainIlSourcePath(testName);
            return await File.ReadAllTextAsync(ilSourcePath);
        }
    }
}