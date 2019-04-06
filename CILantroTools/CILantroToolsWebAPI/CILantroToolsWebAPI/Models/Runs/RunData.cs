using CILantroToolsWebAPI.Enums;
using CILantroToolsWebAPI.ReadModels.Runs;

namespace CILantroToolsWebAPI.Models.Runs
{
    public class RunData
    {
        public RunStatus Status { get; set; }

        public RunOutcome Outcome { get; set; }

        public int ProcessedTestsCount { get; set; }

        public int? ProcessedForMilliseconds { get; set; }

        public string CurrentTestName { get; set; }

        public TestRunStep? CurrentTestStep { get; set; }

        public int? CurrentTestStepIndex { get; set; }

        public int TestStepsCount { get; set; }

        public int? CurrentItemIndex { get; set; }

        public string CurrentItemName { get; set; }

        public int AllItemsCount { get; set; }

        public RunData(RunReadModel run)
        {
            Status = run.Status;
            Outcome = run.Outcome;
            ProcessedTestsCount = run.ProcessedTestsCount;
            ProcessedForMilliseconds = run.ProcessedForMilliseconds;
            TestStepsCount = TestRunStepHelper.GetAllSteps().Count;
        }
    }
}