using CILantroToolsWebAPI.Db;
using System;

namespace CILantroToolsWebAPI.DbModels
{
    public class Category : IKeyEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}