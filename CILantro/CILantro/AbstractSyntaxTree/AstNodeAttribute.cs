using System;

namespace CILantro.AbstractSyntaxTree
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class AstNodeAttribute : Attribute
    {
        public string TermName { get; }

        public AstNodeAttribute(string termName)
        {
            TermName = termName;
        }
    }
}