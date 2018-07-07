using CILantroTestManager.Configuration;
using CILantroTestManager.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CILantroTestManager.Services
{
    public class TestsService
    {
        private readonly string TESTS_DIRECTORY_PATH = ConfigurationProvider.TestsDirectoryPath;

        private readonly string TEST_FILE_NAME_PATTERN = "*.exe";

        public IEnumerable<TestCandidateEntity> FindAllTestCandidates()
        {
            return Directory.GetFiles(TESTS_DIRECTORY_PATH, TEST_FILE_NAME_PATTERN, SearchOption.AllDirectories)
                .Where(testCandidatePath => testCandidatePath.Contains(@"\Release\"))
                .Where(testCandidatePath => !testCandidatePath.Contains(@"\obj\"))
                .OrderBy(testCandidatePath => Path.GetFileNameWithoutExtension(testCandidatePath))
                .Select(path => new TestCandidateEntity
                {
                    FileName = Path.GetFileNameWithoutExtension(path),
                    Path = path,
                    ShortPath = path.Substring(TESTS_DIRECTORY_PATH.Length)
                });
        }
    }
}