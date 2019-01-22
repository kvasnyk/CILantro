using CILantroToolsWebAPI.Models.Tests;
using CILantroToolsWebAPI.Services;
using CILantroToolsWebAPI.Settings;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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

        public TestsController(IOptions<AppSettings> appSettings)
        {
            _testsService = new TestsService(appSettings);
        }

        [HttpGet("find")]
        public async Task<IEnumerable<TestCandidate>> FindTestsAsync()
        {
            return await _testsService.FindTestCandidatesAsync();
        }
    }
}