using CILantro.Tools.WebAPI.BindingModels.Categories;
using System.Threading.Tasks;
using System.Web.Http;

namespace CILantro.Tools.WebAPI.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiControllerBase
    {
        [HttpPost]
        [Route("create-category")]
        public async Task<IHttpActionResult> CreateCategory(CreateCategoryBindingModel model)
        {
            return Ok();
        }
    }
}