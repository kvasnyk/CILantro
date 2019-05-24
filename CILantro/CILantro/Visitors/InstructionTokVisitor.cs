using CILantro.Instructions;
using CILantro.Instructions.Tok;
using System;

namespace CILantro.Visitors
{
    public abstract class InstructionTokVisitor
    {
        public void VisitInstructionTok(CilInstructionTok instruction)
        {
            if (instruction is LoadTokenInstruction loadTokenInstruction)
                VisitLoadTokenInstruction(loadTokenInstruction);
            else
                throw new ArgumentException($"CIL instruction tok cannot be recognized: '{instruction.ToString()}'.");
        }

        protected abstract void VisitLoadTokenInstruction(LoadTokenInstruction instruction);
    }
}