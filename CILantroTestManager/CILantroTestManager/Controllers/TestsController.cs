using CILantroTestManager.Configuration;
using CILantroTestManager.ViewModels.Tests;
using System.IO;
using System.Web.Mvc;

namespace CILantroTestManager.Controllers
{
    public class TestsController : Controller
    {
        private readonly string TESTS_DIRECTORY_PATH = ConfigurationProvider.TestsDirectoryPath;
        private readonly string TEST_FILE_NAME_PATTERN = ConfigurationProvider.TestFileNamePattern;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Find()
        {
            var testCandidates = Directory.GetFiles(TESTS_DIRECTORY_PATH, TEST_FILE_NAME_PATTERN, SearchOption.AllDirectories);

            var model = new TestsFindViewModel
            {
                TestCandidates = testCandidates
            };

            return View(model);
        }
    }
}