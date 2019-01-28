using CILantroToolsWebAPI.Db;
using System;

namespace CILantroToolsWebAPI.DbModels
{
    public class Subcategory : IKeyEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}