using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.Enums;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.ReadModels.Runs
{
    public class RunReadModel : IKeyReadModel
    {
        public Guid Id { get; set; }

        public int IntId { get; set; }

        public RunType Type { get; set; }

        public RunStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public int AllTestsCount { get; set; }

        public int ProcessedTestsCount { get; set; }

        public int? ProcessedForMilliseconds { get; set; }

        public DateTime? ProcessingStartedOn { get; set; }

        public DateTime? ProcessingFinishedOn { get; set; }

        public List<TestRunReadModel> TestRuns { get; set; }
    }

    public class RunReadModelMapping : ReadModelMappingBase<Run, RunReadModel>
    {
        private readonly Expression<Func<TestRun, TestRunReadModel>> _testRunMapping = new TestRunReadModelMapping().Mapping.Expand();

        public override Expression<Func<Run, RunReadModel>> Mapping => run => new RunReadModel
        {
            Id = run.Id,
            IntId = run.IntId,
            Type = run.Type,
            Status = run.Status,
            CreatedOn = run.CreatedOn,
            AllTestsCount = run.TestRuns.Count(),
            ProcessedTestsCount = run.ProcessedTestsCount,
            ProcessingStartedOn = run.ProcessingStartedOn,
            ProcessingFinishedOn = run.ProcessingFinishedOn,
            ProcessedForMilliseconds = run.ProcessingStartedOn.HasValue && run.ProcessingFinishedOn.HasValue ? (int?)(run.ProcessingFinishedOn - run.ProcessingStartedOn).Value.TotalMilliseconds : null,
            TestRuns = run.TestRuns.Select(tr => _testRunMapping.Invoke(tr)).ToList()
        };
    }
}