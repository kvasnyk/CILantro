using CILantroToolsWebAPI.DbModels;
using System;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.ReadModels.Categories
{
    public class CategoryReadModel : IKeyReadModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public class CategoryReadModelMapping : ReadModelMappingBase<Category, CategoryReadModel>
    {
        public override Expression<Func<Category, CategoryReadModel>> Mapping => category => new CategoryReadModel
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}