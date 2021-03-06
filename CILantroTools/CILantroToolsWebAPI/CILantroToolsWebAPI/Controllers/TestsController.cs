﻿using CILantroToolsWebAPI.BindingModels.Tests;
using CILantroToolsWebAPI.Models.Tests;
using CILantroToolsWebAPI.ReadModels.Tests;
using CILantroToolsWebAPI.Search;
using CILantroToolsWebAPI.Services;
using CILantroToolsWebAPI.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Controllers
{
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

        [HttpGet("check")]
        public async Task<TestsCheck> CheckTestsAsync()
        {
            return await _testsService.CheckTests();
        }

        [HttpPost("create-from-candidate")]
        public async Task<Guid> CreateTestFromCandidateAsync([FromBody]CreateTestFromCandidateBindingModel model)
        {
            return await _testsService.CreateTestFromCandidateAsync(model);
        }

        [HttpGet("{testId}")]
        public async Task<TestInfo> GetTestInfoAsync([FromRoute]Guid testId)
        {
            return await _testsService.GetTestInfoAsync(testId);
        }

        [HttpPost("search")]
        public async Task<SearchResult<TestReadModel>> SearchTestsAsync([FromBody]SearchParameter searchParameter)
        {
            return await _testsService.SearchTestsAsync(searchParameter);
        }

        [HttpPost("{testId}/disable")]
        public async Task DisableTestAsync([FromRoute]Guid testId)
        {
            await _testsService.DisableTestAsync(testId);
        }

        [HttpPost("{testId}/enable")]
        public async Task EnableTestAsync([FromRoute]Guid testId)
        {
            await _testsService.EnableTestAsync(testId);
        }

        [HttpPut("{testId}/edit-disabled-reason")]
        public async Task EditTestDisabledReasonAsync([FromRoute]Guid testId, [FromBody]EditTestDisabledReasonBindingModel model)
        {
            await _testsService.EditTestDisabledReasonAsync(testId, model);
        }

        [HttpPut("{testId}/edit-category")]
        public async Task EditTestCategoryAsync([FromRoute]Guid testId, [FromBody]EditTestCategoryBindingModel model)
        {
            await _testsService.EditTestCategoryAsync(testId, model);
        }

        [HttpPut("{testId}/edit-subcategory")]
        public async Task EditTestSubcategoryAsync([FromRoute]Guid testId, [FromBody]EditTestSubcategoryBindingModel model)
        {
            await _testsService.EditTestSubcategoryAsync(testId, model);
        }

        [HttpPut("{testId}/edit-has-empty-input")]
        public async Task EditTestHasEmptyInputAsync([FromRoute]Guid testId, [FromBody]EditTestHasEmptyInputBindingModel model)
        {
            await _testsService.EditTestHasEmptyInputAsync(testId, model);
        }

        [HttpPut("{testId}/edit-input")]
        public async Task EditTestInputAsync([FromRoute]Guid testId, [FromBody]EditTestInputBindingModel model)
        {
            await _testsService.EditTestInputAsync(testId, model);
        }

        [HttpPut("{testId}/edit-output")]
        public async Task EditTestOutputAsync([FromRoute]Guid testId, [FromBody]EditTestOutputBindingModel model)
        {
            await _testsService.EditTestOutputAsync(testId, model);
        }

        [HttpPost("{testId}/generate-il-sources")]
        public async Task GenerateTestIlSourcesAsync([FromRoute]Guid testId)
        {
            await _testsService.GenerateIlSources(testId);
        }

        [HttpPost("{testId}/generate-exe")]
        public async Task GenerateExeAsync([FromRoute]Guid testId)
        {
            await _testsService.GenerateExe(testId);
        }

        [HttpPost("{testId}/generate-output")]
        public async Task<string> GenerateOutputAsync([FromRoute]Guid testId, [FromBody]GenerateOutputBindingModel model)
        {
            return await _testsService.GenerateOutput(testId, model);
        }

        [HttpPost("{testId}/add-input-output-example")]
        public async Task AddTestInputOutputExampleAsync([FromRoute]Guid testId, [FromBody]AddTestInputOutputExampleBindingModel model)
        {
            await _testsService.AddTestInputOutputExample(testId, model);
        }

        [HttpPost("{testId}/copy-input")]
        public async Task CopyTestInputAsync([FromRoute]Guid testId, [FromBody]CopyTestInputBindingModel model)
        {
            await _testsService.CopyTestInput(testId, model);
        }
    }
}