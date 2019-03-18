using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.Enums;
using System;
using System.Collections.Generic;

namespace CILantroToolsWebAPI.DbModels
{
    public class Run : IKeyEntity
    {
        public Guid Id { get; set; }

        public int IntId { get; set; }

        public RunType Type { get; set; }

        public RunStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ProcessedTestsCount { get; set; }

        public virtual ICollection<TestRun> TestRuns { get; set; }
    }
}