using CILantro.Instructions;
using CILantro.Instructions.Method;
using System;

namespace CILantro.Visitors
{
    public abstract class InstructionMethodVisitor
    {
        public void VisitInstructionMethod(CilInstructionMethod instruction)
        {
            if (instruction is CallInstruction callInstruction)
                VisitCallInstruction(callInstruction);
            else if (instruction is CallVirtualInstruction callVirtualInstruction)
                VisitCallVirtualInstruction(callVirtualInstruction);
            else if (instruction is NewObjectInstruction newObjectInstruction)
                VisitNewObjectInstruction(newObjectInstruction);
            else
                throw new ArgumentException($"CIL instruction method cannot be recognized: '{instruction.ToString()}'.");
        }

        public abstract void VisitCallInstruction(CallInstruction instruction);

        public abstract void VisitCallVirtualInstruction(CallVirtualInstruction instruction);

        public abstract void VisitNewObjectInstruction(NewObjectInstruction instruction);
    }
}