using CILantroToolsWebAPI.Db;
using System;

namespace CILantroToolsWebAPI.DbModels
{
    public class Test : IKeyEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }
    }
}