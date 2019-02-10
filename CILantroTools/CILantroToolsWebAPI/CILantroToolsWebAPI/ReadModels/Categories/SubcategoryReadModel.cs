using CILantroToolsWebAPI.DbModels;
using System;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.ReadModels.Categories
{
    public class SubcategoryReadModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public class SubcategoryReadModelMapping : ReadModelMappingBase<Subcategory, SubcategoryReadModel>
    {
        public override Expression<Func<Subcategory, SubcategoryReadModel>> Mapping => subcategory => new SubcategoryReadModel
        {
            Id = subcategory.Id,
            Name = subcategory.Name
        };
    }
}