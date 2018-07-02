using CILantroTestManager.ViewModels.Tags;
using System.Web.Mvc;

namespace CILantroTestManager.Controllers
{
    public class TagsController : Controller
    {
        public ActionResult Index()
        {
            var model = new TagsIndexViewModel();

            return View(model);
        }

        public ActionResult Add()
        {
            var model = new TagsAddViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(TagsAddViewModel model)
        {
            return RedirectToAction("Index");
        }
    }
}