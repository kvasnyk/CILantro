using CILantroToolsWebAPI.Db;
using System;

namespace CILantroToolsWebAPI.DbModels
{
    public class TestInputOutputExample : IKeyEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Input { get; set; }

        public string Output { get; set; }

        public Guid TestId { get; set; }

        public virtual Test Test { get; set; }
    }
}