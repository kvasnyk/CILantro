using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.Models.Tests.InputOutput;
using CILantroToolsWebAPI.ReadModels.Categories;
using LinqKit;
using System;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.ReadModels.Tests
{
    public class TestReadModel : IKeyReadModel
    {
        public Guid Id { get; set; }

        public int IntId { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public Guid? CategoryId { get; set; }

        public CategoryReadModel Category { get; set; }

        public Guid? SubcategoryId { get; set; }

        public SubcategoryReadModel Subcategory { get; set; }

        public string MainIlSourcePath { get; set; }

        public string MainIlSource { get; set; }

        public string ExePath { get; set; }

        public string ExePathFull { get; set; }
        
        public bool HasEmptyInput { get; set; }

        public InputOutput Output { get; set; }

        public bool HasCategory => Category != null;

        public bool HasSubcategory => Subcategory != null;

        public bool HasIlSources => !string.IsNullOrEmpty(MainIlSource);

        public bool HasExe => !string.IsNullOrEmpty(ExePath) && !string.IsNullOrEmpty(ExePathFull);

        public bool HasInput => HasEmptyInput;

        public bool HasOutput => Output != null && !Output.IsEmpty;

        public bool IsReady =>
            HasCategory &&
            HasSubcategory &&
            HasIlSources &&
            HasExe &&
            HasInput &&
            HasOutput;
    }

    public class TestReadModelMapping : ReadModelMappingBase<Test, TestReadModel>
    {
        private readonly Expression<Func<Category, CategoryReadModel>> _categoryMapping = new CategoryReadModelMapping().Mapping.Expand();

        private readonly Expression<Func<Subcategory, SubcategoryReadModel>> _subcategoryMapping = new SubcategoryReadModelMapping().Mapping.Expand();

        public override Expression<Func<Test, TestReadModel>> Mapping => test => new TestReadModel
        {
            Id = test.Id,
            IntId = test.IntId,
            Name = test.Name,
            Path = test.Path,
            HasEmptyInput = test.HasEmptyInput,
            Output = test.Output,
            CategoryId = test.CategoryId,
            Category = test.CategoryId.HasValue ? _categoryMapping.Invoke(test.Category) : null,
            SubcategoryId = test.SubcategoryId,
            Subcategory = test.SubcategoryId.HasValue ? _subcategoryMapping.Invoke(test.Subcategory) : null
        };
    }
}