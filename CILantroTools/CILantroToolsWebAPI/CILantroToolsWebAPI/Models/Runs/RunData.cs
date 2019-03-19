using CILantroToolsWebAPI.Enums;
using CILantroToolsWebAPI.ReadModels.Runs;

namespace CILantroToolsWebAPI.Models.Runs
{
    public class RunData
    {
        public RunStatus Status { get; set; }

        public int ProcessedTestsCount { get; set; }

        public int? ProcessedForSeconds { get; set; }

        public int? CurrentTestIntId { get; set; }

        public string CurrentTestName { get; set; }

        public RunData(RunReadModel run)
        {
            Status = run.Status;
            ProcessedTestsCount = run.ProcessedTestsCount;
            ProcessedForSeconds = run.ProcessedForSeconds;
        }
    }
}