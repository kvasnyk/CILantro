using CILantroToolsWebAPI.ReadModels;
using System;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.Search
{
    public abstract class SearchMapper<TReadModel>
        where TReadModel: class, IKeyReadModel
    {
        public abstract Expression<Func<TReadModel, string>> BuildOrderByExpression(string orderBy);

        public Expression<Func<TReadModel, string>> BuildThenByExpression(string thenBy)
        {
            if (string.IsNullOrEmpty(thenBy))
                return null;

            return BuildOrderByExpression(thenBy);
        }

        public abstract Expression<Func<TReadModel, bool>> BuildWhereExpression(SearchFilter filter);
    }
}