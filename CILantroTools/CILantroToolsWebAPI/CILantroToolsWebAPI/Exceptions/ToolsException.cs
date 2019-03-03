using System;

namespace CILantroToolsWebAPI.Exceptions
{
    public class ToolsException : Exception
    {
        public ToolsException(string message)
            : base(message)
        {
        }
    }
}