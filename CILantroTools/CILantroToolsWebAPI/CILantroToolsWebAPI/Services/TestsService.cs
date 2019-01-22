using CILantroToolsWebAPI.Models.Tests;
using CILantroToolsWebAPI.Settings;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Services
{
    public class TestsService
    {
        private readonly IOptions<AppSettings> _appSettings;

        public TestsService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<IEnumerable<TestCandidate>> FindTestCandidatesAsync()
        {
            var testExecs = Directory
                .GetFiles(_appSettings.Value.TestsDirectoryPath, "*.exe", SearchOption.AllDirectories)
                .Where(path => path.Contains(@"\Release\"))
                .Where(path => !path.Contains(@"\obj\"))
                .OrderBy(path => Path.GetFileNameWithoutExtension(path));

            var testCandidates = testExecs.Select(testExecPath => new TestCandidate
            {
                Name = Path.GetFileNameWithoutExtension(testExecPath),
                Path = testExecPath.Substring(_appSettings.Value.TestsDirectoryPath.Length)
            });

            return testCandidates;
        }
    }
}