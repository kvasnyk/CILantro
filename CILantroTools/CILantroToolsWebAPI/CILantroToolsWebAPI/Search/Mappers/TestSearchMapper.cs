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

            throw new ArgumentException($"{nameof(orderBy)} property '{orderBy}' cannot be recognized.");
        }
    }
}