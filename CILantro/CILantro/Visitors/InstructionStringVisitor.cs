using CILantro.Instructions;
using CILantro.Instructions.String;
using System;

namespace CILantro.Visitors
{
    public abstract class InstructionStringVisitor
    {
        public void VisitInstructionString(CilInstructionString instruction)
        {
            if (instruction is LoadStringInstruction loadStringInstruction)
                VisitLoadStringInstruction(loadStringInstruction);
            else
                throw new ArgumentException($"CIL instruction string cannot be recognized: '{instruction.ToString()}'.");
        }

        protected abstract void VisitLoadStringInstruction(LoadStringInstruction instruction);
    }
}