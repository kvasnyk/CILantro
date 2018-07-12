using CILantroTestManager.Configuration;
using CILantroTestManager.Database;
using CILantroTestManager.Entities;
using CILantroTestManager.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CILantroTestManager.Services
{
    public class TestsService
    {
        private readonly string TESTS_DIRECTORY_PATH = ConfigurationProvider.TestsDirectoryPath;

        private readonly string TESTS_DATA_DIRECTORY_PATH = ConfigurationProvider.TestsDataDirectoryPath;

        private readonly string ILDASM_PATH = ConfigurationProvider.IldasmPath;

        private readonly string TEST_FILE_NAME_PATTERN = "*.exe";

        private readonly string IL_SOURCES_DIRECTORY_NAME = "il-sources";

        private string IL_SOURCES_DIRECTORY_PATH => Path.Combine(TESTS_DATA_DIRECTORY_PATH, IL_SOURCES_DIRECTORY_NAME);

        private readonly TestsRepository _testsRepository;

        public TestsService()
        {
            var applicationDbContext = ApplicationDbContext.Create();

            _testsRepository = new TestsRepository(applicationDbContext);

            EnsureDirectoryExists(IL_SOURCES_DIRECTORY_PATH);
        }

        public IEnumerable<TestCandidateEntity> FindAllTestCandidates()
        {
            var existingTests = _testsRepository.ReadAll();

            return Directory.GetFiles(TESTS_DIRECTORY_PATH, TEST_FILE_NAME_PATTERN, SearchOption.AllDirectories)
                .Where(testCandidatePath => testCandidatePath.Contains(@"\Release\"))
                .Where(testCandidatePath => !testCandidatePath.Contains(@"\obj\"))
                .OrderBy(testCandidatePath => Path.GetFileNameWithoutExtension(testCandidatePath))
                .Select(path => new TestCandidateEntity
                {
                    FileName = Path.GetFileNameWithoutExtension(path),
                    Path = path,
                    ShortPath = path.Substring(TESTS_DIRECTORY_PATH.Length)
                })
                .Where(testCandidate => !existingTests.Any(et => et.Name == testCandidate.FileName && et.Path == testCandidate.ShortPath));
        }

        public void CreateTest(string name, string shortPath, Guid categoryId, Guid subcategoryId)
        {
            var newTest = new TestEntity
            {
                Id = Guid.NewGuid(),
                Name = name,
                Path = shortPath,
                CategoryId = categoryId,
                SubcategoryId = subcategoryId
            };

            _testsRepository.Create(newTest);
        }

        public TestEntity ReadTest(Guid testId)
        {
            return _testsRepository.ReadAll().SingleOrDefault(t => t.Id == testId);
        }

        public IEnumerable<TestEntity> ReadAllTests()
        {
            return _testsRepository.ReadAll().OrderBy(t => t.Name);
        }

        public void GenerateIlSource(Guid testId)
        {
            var test = ReadTest(testId);

            var fullTestPath = BuildFullTestPath(test);
            var ilSourcePath = BuildIlSourcePath(test.Name);

            EnsureDirectoryExists(Path.GetDirectoryName(ilSourcePath));

            var ildasmArguments = $"\"{fullTestPath}\" /output=\"{ilSourcePath}\"";
            var ildasmProcessStartInfo = new ProcessStartInfo(ILDASM_PATH, ildasmArguments)
            {
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var ildasmProcess = Process.Start(ildasmProcessStartInfo);
            ildasmProcess.WaitForExit();
        }

        public bool CheckIfIlSourceExists(string testName)
        {
            var ilSourcePath = BuildIlSourcePath(testName);
            return File.Exists(ilSourcePath);
        }

        private void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private string BuildFullTestPath(TestEntity test)
        {
            return TESTS_DIRECTORY_PATH + test.Path;
        }

        private string BuildIlSourcePath(string testName)
        {
            var outputFileName = testName + ".il";
            var outputFilePath = Path.Combine(IL_SOURCES_DIRECTORY_PATH, testName, outputFileName);
            return outputFilePath;
        }
    }
}