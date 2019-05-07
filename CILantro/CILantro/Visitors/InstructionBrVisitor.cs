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
            else if (instruction is BranchShortInstruction branchShortInstruction)
                VisitBranchShortInstruction(branchShortInstruction);
            else if (instruction is BranchOnNotEqualUnsignedShortInstruction branchOnNotEqualUnsignedShortInstruction)
                VisitBranchOnNotEqualUnsignedShortInstruction(branchOnNotEqualUnsignedShortInstruction);
            else
                throw new ArgumentException($"CIL instruction br cannot be recognized: '{instruction.ToString()}'.");
        }

        protected abstract void VisitBranchShortInstruction(BranchShortInstruction instruction);

        protected abstract void VisitBranchOnFalseShortInstruction(BranchOnFalseShortInstruction instruction);

        protected abstract void VisitBranchOnNotEqualUnsignedShortInstruction(BranchOnNotEqualUnsignedShortInstruction instruction);

        protected abstract void VisitBranchOnTrueShortInstruction(BranchOnTrueShortInstruction instruction);
    }
}