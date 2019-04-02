using CILantroToolsWebAPI.BindingModels.Runs;
using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.Hubs;
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
        private readonly TestsHelper _testsHelper;

        private readonly AppKeyRepository<Run> _runsRepository;

        private readonly AppKeyRepository<Test> _testsRepository;

        private readonly HubRunRunner _runRunner;

        public RunsService(
            TestsHelper testsHelper,
            AppKeyRepository<Run> runsRepository,
            AppKeyRepository<Test> testsRepository,
            HubRunRunner runRunner
        )
        {
            _testsHelper = testsHelper;
            _runsRepository = runsRepository;
            _testsRepository = testsRepository;
            _runRunner = runRunner;
        }

        public async Task<SearchResult<RunReadModel>> SearchRunsAsync(SearchParameter searchParameter)
        {
            var result = await _runsRepository.Search<RunReadModel>(searchParameter);
            result.Data = result.Data.OrderByDescending(r => r.CreatedOn);
            return result;
        }

        public async Task<Guid> AddRunAsync(AddRunBindingModel model)
        {
            var allTests = _testsRepository.Read<TestReadModel>().ToList();

            var testRuns = allTests.Where(t => t.IsReady).Select(t => new TestRun
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

            var runId = await _runsRepository.CreateAsync(newRun);

            _runRunner.Run(runId);

            return runId;
        }

        public async Task DeleteRunAsync(Guid runId)
        {
            if (_runRunner.ProcessingRun?.Id == runId)
                await _runRunner.CancelExistingRun();

            await _runsRepository.DeleteAsync(r => r.Id == runId);
        }
    }
}