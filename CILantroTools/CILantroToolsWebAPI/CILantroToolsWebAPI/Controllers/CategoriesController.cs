using CILantroToolsWebAPI.BindingModels.Categories;
using CILantroToolsWebAPI.ReadModels.Categories;
using CILantroToolsWebAPI.Search;
using CILantroToolsWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly CategoriesService _categoriesService;

        public CategoriesController(CategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet("search")]
        public async Task<SearchResult<CategoryReadModel>> SearchCategoriesAsync([FromBody]SearchParameter searchParameter)
        {
            return await _categoriesService.SearchCategoriesAsync(searchParameter);
        }

        [HttpPost("add")]
        public async Task<Guid> AddCategoryAsync([FromBody]AddCategoryBindingModel model)
        {
            return await _categoriesService.AddCategoryAsync(model);
        }

        [HttpDelete("{categoryId}/delete")]
        public async Task DeleteCategoryAsync([FromRoute]Guid categoryId)
        {
            await _categoriesService.DeleteCategoryAsync(categoryId);
        }

        [HttpPost("add-subcategory")]
        public async Task<Guid> AddSubcategoryAsync([FromBody]AddSubcategoryBindingModel model)
        {
            return await _categoriesService.AddSubcategoryAsync(model);
        }
    }
}