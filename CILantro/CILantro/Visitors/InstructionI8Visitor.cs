using CILantro.Instructions;
using CILantro.Instructions.I8;
using System;

namespace CILantro.Visitors
{
    public abstract class InstructionI8Visitor
    {
        public void VisitInstructionI8(CilInstructionI8 instruction)
        {
            if (instruction is LoadConstI8Instruction loadConstI8Instruction)
                VisitLoadConstI8Instruction(loadConstI8Instruction);
            else
                throw new ArgumentException($"CIL instruction i8 cannot be recognized: '{instruction.ToString()}'.");
        }

        protected abstract void VisitLoadConstI8Instruction(LoadConstI8Instruction instruction);
    }
}