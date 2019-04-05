using CILantroToolsWebAPI.ReadModels.Tests;
using System;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.Search.Mappers
{
    public class TestSearchMapper : SearchMapper<TestReadModel>
    {
        public override Expression<Func<TestReadModel, string>> BuildOrderByExpression(string orderBy)
        {
            if (orderBy.Equals(nameof(TestReadModel.Name), StringComparison.InvariantCultureIgnoreCase))
                return t => t.Name;
            if (orderBy.Equals(nameof(TestReadModel.CreatedOn), StringComparison.InvariantCultureIgnoreCase))
                return t => t.CreatedOn.ToString("o");
            if (orderBy.Equals(nameof(TestReadModel.LastOpenedOn), StringComparison.InvariantCultureIgnoreCase))
                return t => t.LastOpenedOn.ToString("o");

            throw new ArgumentException($"{nameof(orderBy)} property '{orderBy}' cannot be recognized.");
        }
    }
}