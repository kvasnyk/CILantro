using CILantroToolsWebAPI.BindingModels.Runs;
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

        [HttpPost("add")]
        public async Task<Guid> AddRunAsync([FromBody]AddRunBindingModel model)
        {
            return await _runsService.AddRunAsync(model);
        }
    }
}