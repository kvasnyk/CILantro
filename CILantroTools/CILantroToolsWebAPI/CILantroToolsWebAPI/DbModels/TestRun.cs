using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.Enums;
using System;
using System.Collections.Generic;

namespace CILantroToolsWebAPI.DbModels
{
    public class TestRun : IKeyEntity
    {
        public Guid Id { get; set; }

        public bool HasBeenProcessed { get; set; }

        public RunOutcome Outcome { get; set; }

        public Guid TestId { get; set; }

        public virtual Test Test { get; set; }

        public Guid RunId { get; set; }

        public virtual Run Run { get; set; }

        public virtual ICollection<TestRunStepInfo> Steps { get; set; }
    }
}