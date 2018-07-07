using CILantroTestManager.ViewModels.Categories;
using System.Web.Mvc;

namespace CILantroTestManager.Controllers
{
    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            var model = new CategoriesIndexViewModel();

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
            return RedirectToAction("Index");
        }
    }
}