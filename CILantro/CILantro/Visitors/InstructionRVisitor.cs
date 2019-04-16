using CILantro.Instructions;
using CILantro.Instructions.R;
using System;

namespace CILantro.Visitors
{
    public abstract class InstructionRVisitor
    {
        public void VisitInstructionR(CilInstructionR instruction)
        {
            if (instruction is LoadConstR4Instruction loadConstR4Instruction)
                VisitLoadConstR4Instruction(loadConstR4Instruction);
            else if (instruction is LoadConstR8Instruction loadConstR8Instruction)
                VisitLoadConstR8Instruction(loadConstR8Instruction);
            else
                throw new ArgumentException($"CIL instruction i cannot be recognized: '{instruction.ToString()}'.");
        }

        protected abstract void VisitLoadConstR4Instruction(LoadConstR4Instruction instruction);

        protected abstract void VisitLoadConstR8Instruction(LoadConstR8Instruction instruction);
    }
}