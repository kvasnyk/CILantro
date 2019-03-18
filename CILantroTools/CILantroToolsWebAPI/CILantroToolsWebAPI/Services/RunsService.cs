using CILantroToolsWebAPI.BindingModels.Runs;
using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.ReadModels.Runs;
using CILantroToolsWebAPI.ReadModels.Tests;
using CILantroToolsWebAPI.Search;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Services
{
    public class RunsService
    {
        private readonly AppKeyRepository<Run> _runsRepository;

        private readonly AppKeyRepository<Test> _testsRepository;

        public RunsService(
            AppKeyRepository<Run> runsRepository,
            AppKeyRepository<Test> testsRepository
        )
        {
            _runsRepository = runsRepository;
            _testsRepository = testsRepository;
        }

        public async Task<SearchResult<RunReadModel>> SearchRunsAsync(SearchParameter searchParameter)
        {
            var result = await _runsRepository.Search<RunReadModel>(searchParameter);
            result.Data = result.Data.OrderByDescending(r => r.CreatedOn);
            return result;
        }

        public async Task<Guid> AddRunAsync(AddRunBindingModel model)
        {
            var allTests = _testsRepository.Read<TestReadModel>();

            var testRuns = allTests.Select(t => new TestRun
            {
                Id = Guid.NewGuid(),
                TestId = t.Id
            }).ToList();

            var newRun = new Run
            {
                Id = Guid.NewGuid(),
                Type = model.Type,
                CreatedOn = DateTime.Now,
                TestRuns = testRuns
            };

            return await _runsRepository.CreateAsync(newRun);
        }
    }
}