using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.Enums;
using System;
using System.Collections.Generic;

namespace CILantroToolsWebAPI.DbModels
{
    public class Category : IKeyEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public BaseLanguage? Language { get; set; }

        public virtual ICollection<Subcategory> Subcategories { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}