using CILantroToolsWebAPI.BindingModels.Tests;
using CILantroToolsWebAPI.Models.Tests;
using CILantroToolsWebAPI.ReadModels.Tests;
using CILantroToolsWebAPI.Search;
using CILantroToolsWebAPI.Services;
using CILantroToolsWebAPI.Settings;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Controllers
{
    [EnableCors("AllowEverything")]
    [Produces("application/json")]
    [Route("api/tests")]
    public class TestsController : Controller
    {
        private readonly TestsService _testsService;

        public TestsController(IOptions<AppSettings> appSettings, TestsService testsService)
        {
            _testsService = testsService;
        }

        [HttpGet("find")]
        public async Task<IEnumerable<TestCandidate>> FindTestsAsync()
        {
            return await _testsService.FindTestCandidatesAsync();
        }

        [HttpPost("create-from-candidate")]
        public async Task<Guid> CreateTestFromCandidateAsync([FromBody]CreateTestFromCandidateBindingModel model)
        {
            return await _testsService.CreateTestFromCandidateAsync(model);
        }

        [HttpGet("{testId}")]
        public async Task<TestReadModel> GetTestAsync([FromRoute]Guid testId)
        {
            return await _testsService.GetTestAsync(testId);
        }

        [HttpGet("search")]
        public async Task<SearchResult<TestReadModel>> SearchTestsAsync([FromBody]SearchParameter searchParameter)
        {
            return await _testsService.SearchTestsAsync(searchParameter);
        }
    }
}