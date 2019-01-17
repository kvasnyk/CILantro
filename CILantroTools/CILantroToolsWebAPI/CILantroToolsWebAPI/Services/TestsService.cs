using CILantroToolsWebAPI.Models.Tests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Services
{
    public class TestsService
    {
        public async Task<IEnumerable<TestCandidate>> FindTestCandidatesAsync()
        {
            return new List<TestCandidate>
            {
                new TestCandidate
                {
                    Name = "Test1"
                },
                new TestCandidate
                {
                    Name = "Test2"
                }
            };
        }
    }
}