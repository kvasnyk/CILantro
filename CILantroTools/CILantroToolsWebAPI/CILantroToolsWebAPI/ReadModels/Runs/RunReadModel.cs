using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.Enums;
using System;
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
    }

    public class RunReadModelMapping : ReadModelMappingBase<Run, RunReadModel>
    {
        public override Expression<Func<Run, RunReadModel>> Mapping => run => new RunReadModel
        {
            Id = run.Id,
            IntId = run.IntId,
            Type = run.Type,
            Status = run.Status,
            CreatedOn = run.CreatedOn
        };
    }
}