using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.Enums;
using System;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.ReadModels.Runs
{
    public class TestRunReadModel : IKeyReadModel
    {
        public Guid Id { get; set; }

        public Guid RunId { get; set; }

        public bool HasBeenProcessed { get; set; }

        public Guid TestId { get; set; }

        public RunOutcome Outcome { get; set; }

        public string TestName { get; set; }
    }

    public class TestRunReadModelMapping : ReadModelMappingBase<TestRun, TestRunReadModel>
    {
        public override Expression<Func<TestRun, TestRunReadModel>> Mapping => testRun => new TestRunReadModel
        {
            Id = testRun.Id,
            HasBeenProcessed = testRun.HasBeenProcessed,
            TestId = testRun.TestId,
            Outcome = testRun.Outcome,
            TestName = testRun.Test.Name,
            RunId = testRun.RunId
        };
    }
}