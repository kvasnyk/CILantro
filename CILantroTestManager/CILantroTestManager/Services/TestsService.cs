﻿using CILantroTestManager.Configuration;
using CILantroTestManager.Database;
using CILantroTestManager.Entities;
using CILantroTestManager.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CILantroTestManager.Services
{
    public class TestsService
    {
        private readonly string TESTS_DIRECTORY_PATH = ConfigurationProvider.TestsDirectoryPath;

        private readonly string TEST_FILE_NAME_PATTERN = "*.exe";

        private readonly TestsRepository _testsRepository;

        public TestsService()
        {
            var applicationDbContext = ApplicationDbContext.Create();

            _testsRepository = new TestsRepository(applicationDbContext);
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

        public IEnumerable<TestEntity> ReadAllTests()
        {
            return _testsRepository.ReadAll().OrderBy(t => t.Name);
        }
    }
}