using System;

namespace CILantroToolsWebAPI.Extensions
{
    public static class StringExtensions
    {
        public static bool EqualsInvariant(this string a, string b)
        {
            return a.Equals(b, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}