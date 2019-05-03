using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.Models.Tests.InputOutput;
using System;
using System.Collections.Generic;

namespace CILantroToolsWebAPI.DbModels
{
    public class Test : IKeyEntity
    {
        public Guid Id { get; set; }

        public int IntId { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public bool HasEmptyInput { get; set; }

        public InputOutput Input { get; set; }

        public InputOutput Output { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime LastOpenedOn { get; set; }

        public bool HasIlSources { get; set; }

        public bool HasExe { get; set; }

        public Guid? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public Guid? SubcategoryId { get; set; }

        public virtual Subcategory Subcategory { get; set; }

        public virtual ICollection<TestInputOutputExample> IoExamples { get; set; }

        public virtual ICollection<TestRun> TestRuns { get; set; }
    }
}