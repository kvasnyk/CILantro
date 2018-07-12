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

        private readonly string ILASM_PATH = ConfigurationProvider.IlasmPath;

        private readonly string ILDASM_PATH = ConfigurationProvider.IldasmPath;

        private readonly string TEST_FILE_NAME_PATTERN = "*.exe";

        private readonly string IL_SOURCES_DIRECTORY_NAME = "il-sources";

        private readonly string EXECS_DIRECTORY_NAME = "execs";

        private string IL_SOURCES_DIRECTORY_PATH => Path.Combine(TESTS_DATA_DIRECTORY_PATH, IL_SOURCES_DIRECTORY_NAME);

        private string EXECS_DIRECTORY_PATH => Path.Combine(TESTS_DATA_DIRECTORY_PATH, EXECS_DIRECTORY_NAME);

        private readonly TestsRepository _testsRepository;

        public TestsService()
        {
            var applicationDbContext = ApplicationDbContext.Create();

            _testsRepository = new TestsRepository(applicationDbContext);

            EnsureDirectoryExists(IL_SOURCES_DIRECTORY_PATH);
            EnsureDirectoryExists(EXECS_DIRECTORY_PATH);
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

        public void GenerateExe(Guid testId)
        {
            var test = ReadTest(testId);

            var ilSourcePath = BuildIlSourcePath(test.Name);
            var exePath = BuildExePath(test.Name);

            EnsureDirectoryExists(Path.GetDirectoryName(exePath));

            var ilasmArguments = $"\"{ilSourcePath}\" /output=\"{exePath}\"";
            var ilasmProcessStartInfo = new ProcessStartInfo(ILASM_PATH, ilasmArguments)
            {
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var ilasmProcess = Process.Start(ilasmProcessStartInfo);
            ilasmProcess.WaitForExit();
        }

        public bool CheckIfIlSourceExists(string testName)
        {
            var ilSourcePath = BuildIlSourcePath(testName);
            return File.Exists(ilSourcePath);
        }

        public bool CheckIfExeExists(string testName)
        {
            var exePath = BuildExePath(testName);
            return File.Exists(exePath);
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
            var ilSourceFileName = testName + ".il";
            var ilSourcePath = Path.Combine(IL_SOURCES_DIRECTORY_PATH, testName, ilSourceFileName);
            return ilSourcePath;
        }

        private string BuildExePath(string testName)
        {
            var exeFileName = testName + ".exe";
            var exePath = Path.Combine(EXECS_DIRECTORY_PATH, testName, exeFileName);
            return exePath;
        }
    }
}