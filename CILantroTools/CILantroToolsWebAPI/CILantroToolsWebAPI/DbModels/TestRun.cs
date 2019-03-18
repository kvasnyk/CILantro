using CILantroToolsWebAPI.Db;
using System;

namespace CILantroToolsWebAPI.DbModels
{
    public class TestRun : IKeyEntity
    {
        public Guid Id { get; set; }

        public Guid TestId { get; set; }

        public virtual Test Test { get; set; }

        public Guid RunId { get; set; }

        public virtual Run Run { get; set; }
    }
}