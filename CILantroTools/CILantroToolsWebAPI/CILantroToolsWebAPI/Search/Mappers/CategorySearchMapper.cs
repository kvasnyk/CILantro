using CILantroToolsWebAPI.ReadModels.Categories;
using System;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.Search.Mappers
{
    public class CategorySearchMapper : SearchMapper<CategoryReadModel>
    {
        public override Expression<Func<CategoryReadModel, string>> BuildOrderByExpression(string orderBy)
        {
            if (orderBy.Equals(nameof(CategoryReadModel.Name), StringComparison.InvariantCultureIgnoreCase))
                return c => c.Name;

            throw new ArgumentException($"{nameof(orderBy)} property '{orderBy}' cannot be recognized.");
        }

        public override Expression<Func<CategoryReadModel, bool>> BuildWhereExpression(SearchFilter filter)
        {
            throw new ArgumentException($"Cannot build filter expression for property '{filter.Property}' and type '{filter.Type}'.");
        }
    }
}