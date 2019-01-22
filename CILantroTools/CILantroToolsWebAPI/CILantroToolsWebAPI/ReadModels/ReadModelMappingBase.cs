using System;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.ReadModels
{
    public abstract class ReadModelMappingBase<TEntity, TReadModel>
    {
        public abstract Expression<Func<TEntity, TReadModel>> Mapping { get; }
    }
}