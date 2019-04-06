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
            else
                throw new ArgumentException($"CIL instruction i cannot be recognized: '{instruction.ToString()}'.");
        }

        protected abstract void VisitLoadConstI4ShortInstruction(LoadConstI4ShortInstruction instruction);
    }
}