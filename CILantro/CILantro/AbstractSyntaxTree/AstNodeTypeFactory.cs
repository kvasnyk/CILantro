using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CILantro.AbstractSyntaxTree
{
    public static class AstNodeTypeFactory
    {
        private static Dictionary<string, Type> AstNodeTypesDictionary { get; }

        static AstNodeTypeFactory()
        {
            AstNodeTypesDictionary = Assembly.GetExecutingAssembly()
                .ExportedTypes
                .Where(et => et.IsClass && !et.IsAbstract)
                .Select(t => new
                {
                    AstNodeAttribute = t.GetCustomAttributes(typeof(AstNodeAttribute)).SingleOrDefault(),
                    AstNodeType = t
                })
                .Where(x => x.AstNodeAttribute != null)
                .ToDictionary(x => (x.AstNodeAttribute as AstNodeAttribute).TermName, x => x.AstNodeType);
        }

        public static Type CreateAstNodeType(string termName)
        {
            AstNodeTypesDictionary.TryGetValue(termName, out Type result);
            if (result != null)
            {
                return result;
            }

            throw new ArgumentException($"Cannot create a node type for term '{termName}'.");
        }
    }
}