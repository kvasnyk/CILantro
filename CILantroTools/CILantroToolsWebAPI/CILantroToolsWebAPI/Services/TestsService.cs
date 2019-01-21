using CILantroToolsWebAPI.Models.Tests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Services
{
    public class TestsService
    {
        public async Task<IEnumerable<TestCandidate>> FindTestCandidatesAsync()
        {
            return Enumerable.Range(1, 100).Select(i => new TestCandidate
            {
                Name = $"TestCandidate{i}"
            });
        }
    }
}