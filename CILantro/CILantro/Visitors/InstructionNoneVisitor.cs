using CILantro.Instructions;
using CILantro.Instructions.None;
using System;

namespace CILantro.Visitors
{
    public abstract class InstructionNoneVisitor
    {
        public void VisitInstructionNone(CilInstructionNone instruction)
        {
            if (instruction is LoadConstI40Instruction loadConstI40Instruction)
                VisitLoadConstI40Intruction(loadConstI40Instruction);
            else if (instruction is ReturnInstruction returnInstruction)
                VisitReturnInstruction(returnInstruction);
            else
                throw new ArgumentException($"CIL instruction none cannot be recognized: '{instruction.ToString()}'.");
        }

        protected abstract void VisitLoadConstI40Intruction(LoadConstI40Instruction instruction);

        protected abstract void VisitReturnInstruction(ReturnInstruction instruction);
    }
}