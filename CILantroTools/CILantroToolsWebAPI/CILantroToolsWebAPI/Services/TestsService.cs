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
            return _testsRepository.Read<TestReadModel>().Single(t => t.Id == testId);
        }

        public async Task<SearchResult<TestReadModel>> SearchTestsAsync(SearchParameter searchParameter)
        {
            return await _testsRepository.Search<TestReadModel>(searchParameter);
        }

        public async Task EditTestCategoryAsync(Guid testId, EditTestCategoryBindingModel model)
        {
            await _testsRepository.UpdateAsync(t => t.Id == testId, test =>
            {
                test.CategoryId = model.CategoryId;
            });
        }
    }
}