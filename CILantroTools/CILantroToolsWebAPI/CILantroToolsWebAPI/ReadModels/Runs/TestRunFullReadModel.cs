using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.ReadModels.Runs
{
    public class TestRunStepInfoReadModel
    {
        public int ProcessedForMilliseconds { get; set; }

        public TestRunStep Step { get; set; }

        public RunOutcome Outcome { get; set; }
    }


    public class TestRunStepItemInfoReadModel
    {
        public string ItemName { get; set; }

        public List<TestRunStepInfoReadModel> Steps { get; set; }
    }

    public class TestRunFullReadModel : IKeyReadModel
    {
        public Guid Id { get; set; }

        public Guid RunId { get; set; }

        public bool HasBeenProcessed { get; set; }

        public Guid TestId { get; set; }

        public RunOutcome Outcome { get; set; }

        public string TestName { get; set; }

        public List<TestRunStepItemInfoReadModel> Items { get; set; }
    }

    public class TestRunFullReadModelMapping : ReadModelMappingBase<TestRun, TestRunFullReadModel>
    {
        public override Expression<Func<TestRun, TestRunFullReadModel>> Mapping => testRun => new TestRunFullReadModel
        {
            Id = testRun.Id,
            HasBeenProcessed = testRun.HasBeenProcessed,
            TestId = testRun.TestId,
            Outcome = testRun.Outcome,
            TestName = testRun.Test.Name,
            RunId = testRun.RunId,
            Items = testRun.Steps.First().Items.Select(i => new TestRunStepItemInfoReadModel
            {
                ItemName = i.Name,
                Steps = testRun.Steps.Select(s => s.Items.Single(it => it.Name == i.Name)).Select(stepItem => new TestRunStepInfoReadModel
                {
                    Step = stepItem.Step.Step,
                    ProcessedForMilliseconds = stepItem.ProcessedForMilliseconds,
                    Outcome = stepItem.Outcome
                }).ToList()
            }).ToList()
        };
    }
}