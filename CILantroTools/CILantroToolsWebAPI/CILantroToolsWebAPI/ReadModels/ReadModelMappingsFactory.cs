using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.ReadModels
{
    public static class ReadModelMappingsFactory
    {
        private static readonly Dictionary<Type, Type> _mappings = new Dictionary<Type, Type>();

        public static void RegisterMappings()
        {
            var mappingTypes = typeof(ReadModelMappingBase<,>).Assembly.ExportedTypes
                .Where(et => et.IsClass && !et.IsAbstract && IsSubclassOfRawGeneric(typeof(ReadModelMappingBase<,>), et));

            foreach (var mappingType in mappingTypes)
            {
                _mappings.Add(mappingType.BaseType.GetGenericArguments()[1], mappingType);
            }
        }

        public static Expression<Func<TEntity, TReadModel>> CreateMapping<TEntity, TReadModel>()
        {
            if (!_mappings.TryGetValue(typeof(TReadModel), out var mappingType))
            {
                throw new KeyNotFoundException($"Read model mapping for read model type '{typeof(TReadModel)}' is not registered.");
            }

            var mapping = (ReadModelMappingBase<TEntity, TReadModel>)mappingType.GetConstructor(Type.EmptyTypes).Invoke(new object[0]);
            return mapping.Mapping.Expand();
        }

        private static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }
    }
}