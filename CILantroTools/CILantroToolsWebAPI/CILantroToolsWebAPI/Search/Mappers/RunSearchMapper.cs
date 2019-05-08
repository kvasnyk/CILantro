using CILantroToolsWebAPI.ReadModels.Runs;
using System;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.Search.Mappers
{
    public class RunSearchMapper : SearchMapper<RunReadModel>
    {
        public override Expression<Func<RunReadModel, string>> BuildOrderByExpression(string orderBy)
        {
            if (orderBy.Equals(nameof(RunReadModel.CreatedOn), StringComparison.InvariantCultureIgnoreCase))
                return r => r.CreatedOn.ToString("o");

            throw new ArgumentException($"{nameof(orderBy)} property '{orderBy}' cannot be recognized.");
        }

        public override Expression<Func<RunReadModel, bool>> BuildWhereExpression(SearchFilter filter)
        {
            throw new ArgumentException($"{nameof(filter.Property)} property '{filter.Property}' cannot be recognized.");
        }
    }
}