using CILantroToolsWebAPI.BindingModels.Tests;
using CILantroToolsWebAPI.Models.Tests;
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
    }
}