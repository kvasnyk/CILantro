using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.Models.Tests.InputOutput;
using CILantroToolsWebAPI.ReadModels.Categories;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.ReadModels.Tests
{
    public class TestReadModel : IKeyReadModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime LastOpenedOn { get; set; }

        public Guid? CategoryId { get; set; }

        public CategoryReadModel Category { get; set; }

        public Guid? SubcategoryId { get; set; }

        public SubcategoryReadModel Subcategory { get; set; }

        public bool HasIlSources { get; set; }

        public bool HasExe { get; set; }

        public bool HasEmptyInput { get; set; }

        public InputOutput Input { get; set; }

        public InputOutput Output { get; set; }

        public List<TestIoExampleReadModel> IoExamples { get; set; }

        public bool HasCategory => Category != null;

        public bool HasSubcategory => Subcategory != null;

        public bool HasInput => HasEmptyInput || Input != null;

        public bool HasOutput => Output != null && !Output.IsEmpty;

        public bool HasIoExample => IoExamples != null && IoExamples.Count > 0;

        public bool IsReady =>
            HasCategory &&
            HasSubcategory &&
            HasIlSources &&
            HasExe &&
            HasInput &&
            HasIoExample;
    }

    public class TestReadModelMapping : ReadModelMappingBase<Test, TestReadModel>
    {
        private readonly Expression<Func<Category, CategoryReadModel>> _categoryMapping = new CategoryReadModelMapping().Mapping.Expand();

        private readonly Expression<Func<Subcategory, SubcategoryReadModel>> _subcategoryMapping = new SubcategoryReadModelMapping().Mapping.Expand();

        private readonly Expression<Func<TestInputOutputExample, TestIoExampleReadModel>> _ioExampleMapping = new TestIoExampleReadModelMapping().Mapping.Expand();

        public override Expression<Func<Test, TestReadModel>> Mapping => test => new TestReadModel
        {
            Id = test.Id,
            Name = test.Name,
            Path = test.Path,
            HasEmptyInput = test.HasEmptyInput,
            Input = test.Input,
            Output = test.Output,
            CategoryId = test.CategoryId,
            Category = test.CategoryId.HasValue ? _categoryMapping.Invoke(test.Category) : null,
            SubcategoryId = test.SubcategoryId,
            Subcategory = test.SubcategoryId.HasValue ? _subcategoryMapping.Invoke(test.Subcategory) : null,
            IoExamples = test.IoExamples.AsQueryable().Select(_ioExampleMapping).OrderByDescending(e => e.Name.Split(new char[] { ' ' })[0]).ThenBy(e => e.Name.Split(new char[] { ' ' })[1]).ToList(),
            HasIlSources = test.HasIlSources,
            HasExe = test.HasExe,
            CreatedOn = test.CreatedOn,
            LastOpenedOn = test.LastOpenedOn
        };
    }
}