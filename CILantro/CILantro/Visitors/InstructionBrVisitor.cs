using CILantro.Instructions;
using CILantro.Instructions.Br;
using System;

namespace CILantro.Visitors
{
    public abstract class InstructionBrVisitor
    {
        public void VisitInstructionBr(CilInstructionBr instruction)
        {
            if (instruction is BranchOnTrueShortInstruction branchOnTrueShortInstruction)
                VisitBranchOnTrueShortInstruction(branchOnTrueShortInstruction);
            else if (instruction is BranchOnFalseShortInstruction branchOnFalseShortInstruction)
                VisitBranchOnFalseShortInstruction(branchOnFalseShortInstruction);
            else
                throw new ArgumentException($"CIL instruction br cannot be recognized: '{instruction.ToString()}'.");
        }

        protected abstract void VisitBranchOnFalseShortInstruction(BranchOnFalseShortInstruction instruction);

        protected abstract void VisitBranchOnTrueShortInstruction(BranchOnTrueShortInstruction instruction);
    }
}