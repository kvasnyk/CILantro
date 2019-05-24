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
            else if (instruction is InitObjectInstruction initObjectInstruction)
                VisitInitObjectInstruction(initObjectInstruction);
            else if (instruction is UnboxAnyInstruction unboxAnyInstruction)
                VisitUnboxAnyInstruction(unboxAnyInstruction);
            else
                throw new ArgumentException($"CIL instruction none cannot be recognized: '{instruction.ToString()}'.");
        }

        public abstract void VisitBoxInstruction(BoxInstruction instruction);

        public abstract void VisitInitObjectInstruction(InitObjectInstruction instruction);

        public abstract void VisitNewArrayInstruction(NewArrayInstruction instruction);

        public abstract void VisitUnboxAnyInstruction(UnboxAnyInstruction instruction);
    }
}