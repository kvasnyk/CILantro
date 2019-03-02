using CILantro.Instructions;
using CILantro.Instructions.None;
using System;

namespace CILantro.Visitors
{
    public abstract class InstructionNoneVisitor
    {
        public void VisitInstructionNone(CilInstructionNone instruction)
        {
            if (instruction is ReturnInstruction returnInstruction)
                VisitReturnInstruction(returnInstruction);
            else
                throw new ArgumentException($"CIL instruction none cannot be recognized: '{instruction.ToString()}'.");
        }

        protected abstract void VisitReturnInstruction(ReturnInstruction instruction);
    }
}