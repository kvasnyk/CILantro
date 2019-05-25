using CILantro.Instructions;
using System;

namespace CILantro.Exceptions
{
    public class InstructionNotSupportedException : Exception
    {
        public InstructionNotSupportedException(CilInstruction instruction)
            : base($"The following instruction is not supported: \"{instruction.ToString()}\".")
        {
        }
    }
}