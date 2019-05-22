using CILantro.Instructions;
using CILantro.Instructions.Switch;
using System;

namespace CILantro.Visitors
{
    public abstract class InstructionSwitchVisitor
    {
        public void VisitInstructionSwitch(CilInstructionSwitch instruction)
        {
            if (instruction is SwitchInstruction switchInstruction)
                VisitSwitchInstruction(switchInstruction);
            else
                throw new ArgumentException($"CIL instruction switch cannot be recognized: '{instruction.ToString()}'.");
        }

        protected abstract void VisitSwitchInstruction(SwitchInstruction instruction);
    }
}