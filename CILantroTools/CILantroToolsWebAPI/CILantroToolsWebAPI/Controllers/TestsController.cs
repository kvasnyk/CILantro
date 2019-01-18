using CILantroToolsWebAPI.Models.Tests;
using CILantroToolsWebAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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

        public TestsController()
        {
            _testsService = new TestsService();
        }

        [HttpGet("find")]
        public async Task<IEnumerable<TestCandidate>> FindTestsAsync()
        {
            return await _testsService.FindTestCandidatesAsync();
        }
    }
}