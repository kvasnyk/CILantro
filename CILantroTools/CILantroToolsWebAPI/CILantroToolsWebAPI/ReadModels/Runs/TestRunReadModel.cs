using CILantroToolsWebAPI.DbModels;
using System;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.ReadModels.Runs
{
    public class TestRunReadModel : IKeyReadModel
    {
        public Guid Id { get; set; }

        public Guid TestId { get; set; }
    }

    public class TestRunReadModelMapping : ReadModelMappingBase<TestRun, TestRunReadModel>
    {
        public override Expression<Func<TestRun, TestRunReadModel>> Mapping => testRun => new TestRunReadModel
        {
            Id = testRun.Id,
            TestId = testRun.TestId
        };
    }
}