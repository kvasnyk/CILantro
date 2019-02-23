using System;

namespace CILantro.Exceptions
{
    public class InitAstNodeException : ArgumentException
    {
        public InitAstNodeException(string astNodeName)
            : base($"Cannot init AST node: ${astNodeName}.")
        {
        }
    }
}