using CILantro.Tools.WebAPI.BindingModels.Categories;
using CILantro.Tools.WebAPI.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace CILantro.Tools.WebAPI.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiControllerBase
    {
        private CategoriesService _categoriesService;

        public CategoriesController(CategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpPost]
        [Route("create-category")]
        public async Task<IHttpActionResult> CreateCategoryAsync(CreateCategoryBindingModel model)
        {
            await _categoriesService.CreateCategoryAsync(model.Name);

            return Ok();
        }
    }
}