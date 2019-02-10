using CILantroToolsWebAPI.Db;
using System;
using System.Collections.Generic;

namespace CILantroToolsWebAPI.DbModels
{
    public class Subcategory : IKeyEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}