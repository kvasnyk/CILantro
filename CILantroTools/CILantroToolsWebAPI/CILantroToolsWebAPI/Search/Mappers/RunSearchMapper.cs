﻿using CILantroToolsWebAPI.Extensions;
using CILantroToolsWebAPI.ReadModels.Runs;
using System;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.Search.Mappers
{
    public class RunSearchMapper : SearchMapper<RunReadModel>
    {
        public override Expression<Func<RunReadModel, string>> BuildOrderByExpression(string orderBy)
        {
            if (orderBy.EqualsInvariant(nameof(RunReadModel.CreatedOn)))
                return r => r.CreatedOn.ToString("o");

            throw new ArgumentException($"{nameof(orderBy)} property '{orderBy}' cannot be recognized.");
        }

        public override Expression<Func<RunReadModel, bool>> BuildWhereExpression(SearchFilter filter)
        {
            if (filter.Type == SearchFilterType.Exact)
            {
                if (filter.Property.EqualsInvariant(nameof(RunReadModel.Outcome)))
                    return r => r.Outcome.ToString().EqualsInvariant(filter.Value);
                if (filter.Property.EqualsInvariant(nameof(RunReadModel.Type)))
                    return r => r.Type.ToString().EqualsInvariant(filter.Value);
            }

            throw new ArgumentException($"Cannot build filter expression for property '{filter.Property}' and type '{filter.Type}'.");
        }
    }
}