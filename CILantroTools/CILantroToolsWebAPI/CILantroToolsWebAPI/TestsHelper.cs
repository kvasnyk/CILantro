using CILantroToolsWebAPI.ReadModels.Tests;
using CILantroToolsWebAPI.Utils;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI
{
    public class TestsHelper
    {
        private readonly Paths _paths;

        public TestsHelper(Paths paths)
        {
            _paths = paths;
        }

        public async Task CompleteTestReadModel(TestReadModel testReadModel)
        {
            testReadModel.MainIlSource = await ReadIlSource(testReadModel.Name);
            if (testReadModel.HasIlSources)
            {
                testReadModel.MainIlSourcePath = _paths.TestsData.IlSources[testReadModel.Name].MainIlSourcePaths.Relative;
                testReadModel.MainIlSourcePathFull = _paths.TestsData.IlSources[testReadModel.Name].MainIlSourcePaths.Absolute;
            }

            var testExePath = _paths.TestsData.Execs[testReadModel.Name].MainExePaths.Absolute;

            if (File.Exists(testExePath))
            {
                testReadModel.ExePath = _paths.TestsData.Execs[testReadModel.Name].MainExePaths.Relative;
                testReadModel.ExePathFull = testExePath;
            }

            var generateExeOutputPath = _paths.TestsData.GenerateExeOutputs[testReadModel.Name].Absolute;
            if (File.Exists(generateExeOutputPath))
            {
                testReadModel.GenerateExeOutput = await File.ReadAllTextAsync(generateExeOutputPath);
            }
        }

        public async Task CompleteTestReadModels(IEnumerable<TestReadModel> testReadModels)
        {
            var tasks = new List<Task>();

            foreach (var testReadModel in testReadModels)
            {
                tasks.Add(CompleteTestReadModel(testReadModel));
            }

            await Task.WhenAll(tasks);
        }

        public async Task<string> ReadIlSource(string testName)
        {
            var ilSourcePath = _paths.TestsData.IlSources[testName].MainIlSourcePaths.Absolute;

            if (!File.Exists(ilSourcePath))
            {
                return null;
            }

            return await File.ReadAllTextAsync(ilSourcePath);
        }
    }
}