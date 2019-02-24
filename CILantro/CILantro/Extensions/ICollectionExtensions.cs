using System.Collections.Generic;

namespace CILantro.Extensions
{
    public static class ICollectionExtensions
    {
        public static void AddIfNotNull<T>(this ICollection<T> collection, T element)
        {
            if (element != null)
                collection.Add(element);
        }
    }
}