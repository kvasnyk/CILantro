﻿using CILantroToolsWebAPI.BindingModels.Runs;
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

        [HttpGet("search")]
        public async Task<SearchResult<RunReadModel>> SearchRunsAsync([FromBody]SearchParameter searchParameter)
        {
            return await _runsService.SearchRunsAsync(searchParameter);
        }

        [HttpPost("add")]
        public async Task<Guid> AddRunAsync([FromBody]AddRunBindingModel model)
        {
            return await _runsService.AddRunAsync(model);
        }
    }
}