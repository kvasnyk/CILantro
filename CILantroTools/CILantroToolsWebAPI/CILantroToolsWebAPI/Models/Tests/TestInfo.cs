using CILantroToolsWebAPI.ReadModels.Tests;

namespace CILantroToolsWebAPI.Models.Tests
{
    public class TestInfo
    {
        public TestReadModel Test { get; set; }

        public string MainIlSource { get; set; }

        public string MainIlSourcePath { get; set; }

        public string ExePath { get; set; }

        public string GenerateExeOutput { get; set; }
    }
}