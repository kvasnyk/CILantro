using System.Collections.Generic;

namespace CILantroToolsWebAPI.Enums
{
    public enum TestRunStep
    {
        GenerateInputFiles = 0,
        GenerateExeOutputFiles = 1,
        GenerateCilAntroOutputFiles = 2,
        CompareOutputFiles = 3
    }

    public static class TestRunStepHelper
    {
        public static TestRunStep GetFirstStep()
        {
            return TestRunStep.GenerateInputFiles;
        }

        public static TestRunStep? GetNextStep(TestRunStep step)
        {
            switch (step)
            {
                case TestRunStep.GenerateInputFiles:
                    return TestRunStep.GenerateExeOutputFiles;
                case TestRunStep.GenerateExeOutputFiles:
                    return TestRunStep.GenerateCilAntroOutputFiles;
                case TestRunStep.GenerateCilAntroOutputFiles:
                    return TestRunStep.CompareOutputFiles;
                default:
                    return null;
            }
        }

        public static List<TestRunStep> GetAllSteps()
        {
            var result = new List<TestRunStep>();

            var step = GetFirstStep() as TestRunStep?;
            while (step.HasValue)
            {
                result.Add(step.Value);
                step = GetNextStep(step.Value);
            }

            return result;
        }

        public static int GetStepIndex(TestRunStep step)
        {
            return GetAllSteps().IndexOf(step);
        }
    }
}