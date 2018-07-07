using CILantroTestManager.Services;
using CILantroTestManager.ViewModels.Categories;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CILantroTestManager.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoriesService _categoriesService;

        public CategoriesController()
        {
            _categoriesService = new CategoriesService();
        }

        public ActionResult Index()
        {
            var categories = _categoriesService.ReadAllCategories().Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            });

            var model = new CategoriesIndexViewModel
            {
                Categories = categories
            };

            return View(model);
        }

        public ActionResult Add()
        {
            var model = new CategoriesAddViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(CategoriesAddViewModel model)
        {
            _categoriesService.CreateCategory(model.Name);

            return RedirectToAction("Index");
        }
    }
}