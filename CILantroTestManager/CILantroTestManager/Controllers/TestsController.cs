using CILantroTestManager.Services;
using CILantroTestManager.ViewModels.Categories;
using CILantroTestManager.ViewModels.Tests;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace CILantroTestManager.Controllers
{
    public class TestsController : Controller
    {
        private readonly CategoriesService _categoriesService;

        private readonly TestsService _testsService;

        public TestsController()
        {
            _categoriesService = new CategoriesService();
            _testsService = new TestsService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Find()
        {
            var testCandidates = _testsService.FindAllTestCandidates().Select(testCandidate => new TestCandidateViewModel
            {
                FileName = testCandidate.FileName,
                Path = testCandidate.Path,
                ShortPath = testCandidate.ShortPath
            });

            var model = new TestsFindViewModel
            {
                TestCandidates = testCandidates
            };

            return View(model);
        }

        public ActionResult Add(string testName)
        {
            var allCategories = _categoriesService.ReadAllCategories().Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Subcategories = c.Subcategories.Select(sc => new SubcategoryViewModel
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    CategoryId = sc.CategoryId
                })
            });

            var model = new TestsAddViewModel
            {
                TestName = testName,
                AllCategories = allCategories
            };

            return View(model);
        }
    }
}