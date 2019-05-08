using CILantroToolsWebAPI.ReadModels.Runs;
using System;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.Search.Mappers
{
    public class TestRunSearchMapper : SearchMapper<TestRunReadModel>
    {
        public override Expression<Func<TestRunReadModel, string>> BuildOrderByExpression(string orderBy)
        {
            if (orderBy.Equals(nameof(TestRunReadModel.Outcome), StringComparison.InvariantCultureIgnoreCase))
                return tr => ((int)tr.Outcome).ToString();
            if (orderBy.Equals(nameof(TestRunReadModel.TestName), StringComparison.InvariantCultureIgnoreCase))
                return tr => tr.TestName;

            throw new ArgumentException($"{nameof(orderBy)} property '{orderBy}' cannot be recognized.");
        }

        public override Expression<Func<TestRunReadModel, bool>> BuildWhereExpression(SearchFilter filter)
        {
            throw new ArgumentException($"{nameof(filter.Property)} property '{filter.Property}' cannot be recognized.");
        }
    }
}