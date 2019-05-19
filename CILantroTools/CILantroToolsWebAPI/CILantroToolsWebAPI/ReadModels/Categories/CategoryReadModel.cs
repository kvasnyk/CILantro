using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.Enums;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.ReadModels.Categories
{
    public class CategoryReadModel : IKeyReadModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<SubcategoryReadModel> Subcategories { get; set; }

        public bool IsAssignedToTest { get; set; }

        public BaseLanguage? Language { get; set; }
    }

    public class CategoryReadModelMapping : ReadModelMappingBase<Category, CategoryReadModel>
    {
        private readonly Expression<Func<Subcategory, SubcategoryReadModel>> _subcategoryMapping = new SubcategoryReadModelMapping().Mapping.Expand();

        public override Expression<Func<Category, CategoryReadModel>> Mapping => category => new CategoryReadModel
        {
            Id = category.Id,
            Name = category.Name,
            Subcategories = category.Subcategories.Select(s => _subcategoryMapping.Invoke(s)).OrderBy(s => s.Name),
            IsAssignedToTest = category.Tests.Any(),
            Language = category.Language
        };
    }
}