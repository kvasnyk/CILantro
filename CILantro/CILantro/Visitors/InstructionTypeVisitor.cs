using CILantro.Instructions;
using CILantro.Instructions.Type;
using System;

namespace CILantro.Visitors
{
    public abstract class InstructionTypeVisitor
    {
        public void VisitInstructionType(CilInstructionType instruction)
        {
            if (instruction is NewArrayInstruction newArrayInstruction)
                VisitNewArrayInstruction(newArrayInstruction);
            else
                throw new ArgumentException($"CIL instruction none cannot be recognized: '{instruction.ToString()}'.");
        }

        public abstract void VisitNewArrayInstruction(NewArrayInstruction instruction);
    }
}