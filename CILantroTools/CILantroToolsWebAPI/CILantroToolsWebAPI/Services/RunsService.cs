using CILantroToolsWebAPI.BindingModels.Runs;
using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.Hubs;
using CILantroToolsWebAPI.ReadModels.Runs;
using CILantroToolsWebAPI.ReadModels.Tests;
using CILantroToolsWebAPI.Search;
using CILantroToolsWebAPI.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Services
{
    public class RunsService
    {
        private readonly TestsHelper _testsHelper;

        private readonly AppKeyRepository<Run> _runsRepository;

        private readonly AppKeyRepository<Test> _testsRepository;

        private readonly AppKeyRepository<TestRun> _testRunsRepository;

        private readonly HubRunRunner _runRunner;

        private readonly Paths _paths;

        public RunsService(
            TestsHelper testsHelper,
            AppKeyRepository<Run> runsRepository,
            AppKeyRepository<Test> testsRepository,
            AppKeyRepository<TestRun> testRunsRepository,
            HubRunRunner runRunner,
            Paths paths
        )
        {
            _testsHelper = testsHelper;
            _runsRepository = runsRepository;
            _testsRepository = testsRepository;
            _testRunsRepository = testRunsRepository;
            _runRunner = runRunner;
            _paths = paths;
        }

        public async Task<SearchResult<RunReadModel>> SearchRunsAsync(SearchParameter searchParameter)
        {
            var result = await _runsRepository.Search<RunReadModel>(searchParameter);
            return result;
        }

        public async Task<SearchResult<TestRunReadModel>> SearchTestRunsAsync(Guid runId, SearchParameter searchParameter)
        {
            var result = await _testRunsRepository.Search<TestRunReadModel>(searchParameter, tr => tr.RunId == runId);
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

        public async Task<Guid> AddSingleTestRunAsync(AddSingleTestRunBindingModel model)
        {
            var testRun = new TestRun
            {
                Id = Guid.NewGuid(),
                TestId = model.TestId
            };

            var newRun = new Run
            {
                Id = Guid.NewGuid(),
                Type = model.Type,
                CreatedOn = DateTime.Now,
                TestRuns = new List<TestRun> { testRun }
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

        public async Task<RunReadModel> GetRunAsync(Guid runId)
        {
            var result = _runsRepository.Read<RunReadModel>().Single(r => r.Id == runId);
            return result;
        }

        public async Task<TestRunFullReadModel> GetFullTestRunAsync(Guid runId, Guid testRunId)
        {
            var result = _testRunsRepository.Read<TestRunFullReadModel>().Single(tr => tr.Id == testRunId && tr.RunId == runId);

            foreach (var resultItem in result.Items)
            {
                resultItem.Input = await File.ReadAllTextAsync(_paths.RunsData[runId][testRunId].Inputs[resultItem.ItemName].Absolute);
                resultItem.ExeOutput = await File.ReadAllTextAsync(_paths.RunsData[runId][testRunId].Outputs[resultItem.ItemName].Absolute);
                resultItem.AntroOutput = await File.ReadAllTextAsync(_paths.RunsData[runId][testRunId].CilAntroOutputs[resultItem.ItemName].Absolute);
            }
            
            return result;
        }
    }
}