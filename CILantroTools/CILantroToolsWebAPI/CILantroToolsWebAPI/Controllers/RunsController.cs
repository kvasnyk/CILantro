using CILantroToolsWebAPI.BindingModels.Runs;
using CILantroToolsWebAPI.ReadModels.Runs;
using CILantroToolsWebAPI.Search;
using CILantroToolsWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/runs")]
    public class RunsController : Controller
    {
        private readonly RunsService _runsService;

        public RunsController(RunsService runsService)
        {
            _runsService = runsService;
        }

        [HttpPost("search")]
        public async Task<SearchResult<RunReadModel>> SearchRunsAsync([FromBody]SearchParameter searchParameter)
        {
            return await _runsService.SearchRunsAsync(searchParameter);
        }

        [HttpPost("{runId}/test-runs/search")]
        public async Task<SearchResult<TestRunReadModel>> SearchTestRunsAsync([FromRoute]Guid runId, [FromBody]SearchParameter searchParameter)
        {
            return await _runsService.SearchTestRunsAsync(runId, searchParameter);
        }

        [HttpPost("add")]
        public async Task<Guid> AddRunAsync([FromBody]AddRunBindingModel model)
        {
            return await _runsService.AddRunAsync(model);
        }

        [HttpPost("add-single")]
        public async Task<Guid> AddSingleTestRunAsync([FromBody]AddSingleTestRunBindingModel model)
        {
            return await _runsService.AddSingleTestRunAsync(model);
        }

        [HttpDelete("{runId}/delete")]
        public async Task DeleteRunAsync([FromRoute]Guid runId)
        {
            await _runsService.DeleteRunAsync(runId);
        }

        [HttpGet("{runId}")]
        public async Task<RunReadModel> GetRunAsync([FromRoute]Guid runId)
        {
            return await _runsService.GetRunAsync(runId);
        }

        [HttpGet("{runId}/test-runs/{testRunId}")]
        public async Task<TestRunFullReadModel> GetFullTestRunAsync([FromRoute]Guid runId, [FromRoute]Guid testRunId)
        {
            return await _runsService.GetFullTestRunAsync(runId, testRunId);
        }
    }
}