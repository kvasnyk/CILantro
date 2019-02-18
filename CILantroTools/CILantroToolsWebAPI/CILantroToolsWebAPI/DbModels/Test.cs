using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.Models.Tests.InputOutput;
using System;

namespace CILantroToolsWebAPI.DbModels
{
    public class Test : IKeyEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public bool HasEmptyInput { get; set; }

        public InputOutput Output { get; set; }

        public Guid? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public Guid? SubcategoryId { get; set; }

        public virtual Subcategory Subcategory { get; set; }
    }
}