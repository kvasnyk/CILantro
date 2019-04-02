using CILantroToolsWebAPI.Db;
using System;

namespace CILantroToolsWebAPI.DbModels
{
    public class TestRunStepItem : IKeyEntity
    {
        public Guid Id { get; set; }

        public int ProcessedForMilliseconds { get; set; }

        public string Name { get; set; }

        public Guid StepId { get; set; }

        public virtual TestRunStepInfo Step { get; set; }
    }
}