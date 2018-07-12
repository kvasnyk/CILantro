using CILantroTestManager.Entities;
using CILantroTestManager.Services;
using CILantroTestManager.ViewModels.Categories;
using CILantroTestManager.ViewModels.Tests;
using System;
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
            var allTests = _testsService.ReadAllTests().Select(t => CreateViewModel(t));
            var model = new TestsIndexViewModel
            {
                SearchResult = allTests
            };

            return View(model);
        }

        public ActionResult Show(Guid testId)
        {
            var test = _testsService.ReadTest(testId);
            var model = CreateViewModel(test);

            return View(model);
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

        public ActionResult Add(string testName, string shortPath)
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
                ShortPath = shortPath,
                AllCategories = allCategories
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(TestsAddViewModel model)
        {
            _testsService.CreateTest(model.TestName, model.ShortPath, model.CategoryId, model.SubcategoryId);

            return RedirectToAction("Index");
        }

        private TestViewModel CreateViewModel(TestEntity test)
        {
            var isIlSourceAvailable = _testsService.CheckIfIlSourceExists(test.Name);
            var isExeAvailable = _testsService.CheckIfExeExists(test.Name);

            var isTestReady = isIlSourceAvailable && isExeAvailable;

            return new TestViewModel
            {
                Id = test.Id,
                Name = test.Name,
                ShortPath = test.Path,
                CategoryName = test.Category.Name,
                SubcategoryName = test.Subcategory.Name,
                IsIlSourceAvailable = isIlSourceAvailable,
                IsExeAvailable = isExeAvailable,
                IsReady = isTestReady
            };
        }
    }
}