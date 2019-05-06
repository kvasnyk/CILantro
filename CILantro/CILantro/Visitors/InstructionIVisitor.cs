using CILantro.Instructions;
using CILantro.Instructions.I;
using System;

namespace CILantro.Visitors
{
    public abstract class InstructionIVisitor
    {
        public void VisitInstructionI(CilInstructionI instruction)
        {
            if (instruction is LoadConstI4ShortInstruction loadConstI4ShortInstruction)
                VisitLoadConstI4ShortInstruction(loadConstI4ShortInstruction);
            else if (instruction is LoadConstI4Instruction loadConstI4Instruction)
                VisitLoadConstI4Instruction(loadConstI4Instruction);
            else
                throw new ArgumentException($"CIL instruction i cannot be recognized: '{instruction.ToString()}'.");
        }

        protected abstract void VisitLoadConstI4Instruction(LoadConstI4Instruction instruction);

        protected abstract void VisitLoadConstI4ShortInstruction(LoadConstI4ShortInstruction instruction);
    }
}