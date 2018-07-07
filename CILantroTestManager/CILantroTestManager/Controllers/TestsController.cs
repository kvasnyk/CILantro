using CILantroTestManager.Configuration;
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
        private readonly string TESTS_DIRECTORY_PATH = ConfigurationProvider.TestsDirectoryPath;

        private readonly string TEST_FILE_NAME_PATTERN = "*.exe";

        private readonly CategoriesService _categoriesService;

        public TestsController()
        {
            _categoriesService = new CategoriesService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Find()
        {
            var testCandidates = Directory.GetFiles(TESTS_DIRECTORY_PATH, TEST_FILE_NAME_PATTERN, SearchOption.AllDirectories)
                .Where(testCandidatePath => testCandidatePath.Contains(@"\Release\"))
                .Where(testCandidatePath => !testCandidatePath.Contains(@"\obj\"))
                .Select(testCandidatePath => new TestCandidateViewModel
                {
                    FileName = Path.GetFileNameWithoutExtension(testCandidatePath),
                    Path = testCandidatePath
                })
                .OrderBy(testCandidate => testCandidate.FileName);
                

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