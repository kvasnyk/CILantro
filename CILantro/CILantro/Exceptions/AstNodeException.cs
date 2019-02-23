using System;

namespace CILantro.Exceptions
{
    public class AstNodeException : ArgumentException
    {
        public AstNodeException(string message)
            : base (message)
        {
        }
    }
}