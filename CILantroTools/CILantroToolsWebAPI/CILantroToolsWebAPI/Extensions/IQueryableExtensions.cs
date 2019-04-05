using CILantroToolsWebAPI.Search;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.Extensions
{
    public static class IQueryableExtensions
    {
        public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, SearchDirection order)
        {
            return order == SearchDirection.Asc ?
                source.OrderBy(keySelector) :
                source.OrderByDescending(keySelector);
        }

        public static IOrderedQueryable<TSource> ThenBy<TSource, TKey>(this IOrderedQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, SearchDirection? order)
        {
            if (keySelector == null)
                return source;

            return !order.HasValue || order == SearchDirection.Asc ?
                source.ThenBy(keySelector) :
                source.ThenByDescending(keySelector);
        }
    }
}