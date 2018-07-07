using CILantroTestManager.Services;
using CILantroTestManager.ViewModels.Categories;
using System;
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
                Name = c.Name,
                Subcategories = c.Subcategories.Select(sc => new SubcategoryViewModel
                {
                    Id = sc.Id,
                    Name = sc.Name
                })
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
        public ActionResult Add(CategoriesAddViewModel model)
        {
            _categoriesService.CreateCategory(model.Name);

            return RedirectToAction("Index");
        }

        public ActionResult AddSubcategory(Guid categoryId)
        {
            var model = new CategoriesAddSubcategoryViewModel
            {
                CategoryId = categoryId
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddSubcategory(CategoriesAddSubcategoryViewModel model)
        {
            _categoriesService.CreateSubcategory(model.CategoryId, model.Name);

            return RedirectToAction("Index");
        }
    }
}