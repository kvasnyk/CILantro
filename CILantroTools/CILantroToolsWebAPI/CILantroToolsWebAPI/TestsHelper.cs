using CILantroToolsWebAPI.Utils;
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