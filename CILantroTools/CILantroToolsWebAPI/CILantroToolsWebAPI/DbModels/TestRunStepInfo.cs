using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.Enums;
using System;
using System.Collections.Generic;

namespace CILantroToolsWebAPI.DbModels
{
    public class TestRunStepInfo : IKeyEntity
    {
        public Guid Id { get; set; }

        public int ProcessedForMilliseconds { get; set; }

        public TestRunStep Step { get; set; }

        public Guid TestRunId { get; set; }

        public virtual TestRun TestRun { get; set; }

        public virtual ICollection<TestRunStepItem> Items { get; set; }
    }
}