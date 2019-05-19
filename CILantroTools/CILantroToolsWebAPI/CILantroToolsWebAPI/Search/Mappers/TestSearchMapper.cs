using CILantroToolsWebAPI.Extensions;
using CILantroToolsWebAPI.ReadModels.Tests;
using System;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.Search.Mappers
{
    public class TestSearchMapper : SearchMapper<TestReadModel>
    {
        public override Expression<Func<TestReadModel, string>> BuildOrderByExpression(string orderBy)
        {
            if (orderBy.EqualsInvariant(nameof(TestReadModel.Name)))
                return t => t.Name;
            if (orderBy.EqualsInvariant(nameof(TestReadModel.CreatedOn)))
                return t => t.CreatedOn.ToString("o");
            if (orderBy.EqualsInvariant(nameof(TestReadModel.LastOpenedOn)))
                return t => t.LastOpenedOn.ToString("o");
            if (orderBy.EqualsInvariant(nameof(TestReadModel.LastRunOutcome)))
                return t => !t.LastRunOutcome.HasValue ? "Z" : t.LastRunOutcome.Value.ToString();

            throw new ArgumentException($"{nameof(orderBy)} property '{orderBy}' cannot be recognized.");
        }

        public override Expression<Func<TestReadModel, bool>> BuildWhereExpression(SearchFilter filter)
        {
            if (filter.Type == SearchFilterType.Exact)
            {
                if (filter.Property.EqualsInvariant(nameof(TestReadModel.CategoryId)))
                    return t => t.CategoryId.ToString().EqualsInvariant(filter.Value);
                if (filter.Property.EqualsInvariant(nameof(TestReadModel.SubcategoryId)))
                    return t => t.SubcategoryId.ToString().EqualsInvariant(filter.Value);
                if (filter.Property.EqualsInvariant(nameof(TestReadModel.IsReady)))
                    return t => t.IsReady.ToString().EqualsInvariant(filter.Value);
                if (filter.Property.EqualsInvariant(nameof(TestReadModel.IsDisabled)))
                    return t => t.IsDisabled.ToString().EqualsInvariant(filter.Value);
                if (filter.Property.EqualsInvariant(nameof(TestReadModel.LastRunOutcome)))
                    return t => t.LastRunOutcome.ToString().EqualsInvariant(filter.Value);
            }

            if (filter.Type == SearchFilterType.Contains)
            {
                if (filter.Property.EqualsInvariant(nameof(TestReadModel.Name)))
                    return t => t.Name.Contains(filter.Value);
            }

            throw new ArgumentException($"Cannot build filter expression for property '{filter.Property}' and type '{filter.Type}'.");
        }
    }
}