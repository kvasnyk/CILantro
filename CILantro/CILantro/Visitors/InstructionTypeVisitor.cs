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
            else if (instruction is BoxInstruction boxInstruction)
                VisitBoxInstruction(boxInstruction);
            else
                throw new ArgumentException($"CIL instruction none cannot be recognized: '{instruction.ToString()}'.");
        }

        public abstract void VisitBoxInstruction(BoxInstruction instruction);

        public abstract void VisitNewArrayInstruction(NewArrayInstruction instruction);
    }
}