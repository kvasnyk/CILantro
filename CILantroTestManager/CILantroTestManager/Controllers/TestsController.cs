using CILantroTestManager.Configuration;
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
    }
}