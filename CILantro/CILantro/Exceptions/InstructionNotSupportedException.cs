using CILantro.Instructions;
using System;

namespace CILantro.Exceptions
{
    public class InstructionNotSupportedException : Exception
    {
        public InstructionNotSupportedException(CilInstruction instruction)
            : base($"Instruction '{instruction.ToString()}' is not supported.")
        {
        }
    }
}