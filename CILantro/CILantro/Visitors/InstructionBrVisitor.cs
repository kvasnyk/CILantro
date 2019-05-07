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
            else if (instruction is BranchOnEqualShortInstruction branchOnEqualShortInstruction)
                VisitBranchOnEqualShortInstruction(branchOnEqualShortInstruction);
            else if (instruction is BranchOnLessThanOrEqualToShortInstruction branchOnLessThanOrEqualToShortInstruction)
                VisitBranchOnLessThanOrEqualToShortInstruction(branchOnLessThanOrEqualToShortInstruction);
            else if (instruction is BranchOnLessThanOrEqualToUnsignedShortInstruction branchOnLessThanOrEqualToUnsignedShortInstruction)
                VisitBranchOnLessThanOrEqualToUnsignedShortInstruction(branchOnLessThanOrEqualToUnsignedShortInstruction);
            else if (instruction is BranchOnLessThanShortInstruction branchOnLessThanShortInstruction)
                VisitBranchOnLessThanShortInstruction(branchOnLessThanShortInstruction);
            else if (instruction is BranchOnLessThanUnsignedShortInstruction branchOnLessThanUnsignedShortInstruction)
                VisitBranchOnLessThanUnsignedShortInstruction(branchOnLessThanUnsignedShortInstruction);
            else if (instruction is BranchOnGreaterThanOrEqualToShortInstruction branchOnGreaterThanOrEqualToShortInstruction)
                VisitBranchOnGreaterThanOrEqualToShortInstruction(branchOnGreaterThanOrEqualToShortInstruction);
            else if (instruction is BranchOnGreaterThanOrEqualToUnsignedShortInstruction branchOnGreaterThanOrEqualToUnsignedShortInstruction)
                VisitBranchOnGreaterThanOrEqualToUnsignedShortInstruction(branchOnGreaterThanOrEqualToUnsignedShortInstruction);
            else
                throw new ArgumentException($"CIL instruction br cannot be recognized: '{instruction.ToString()}'.");
        }

        protected abstract void VisitBranchShortInstruction(BranchShortInstruction instruction);

        protected abstract void VisitBranchOnEqualShortInstruction(BranchOnEqualShortInstruction instruction);

        protected abstract void VisitBranchOnFalseShortInstruction(BranchOnFalseShortInstruction instruction);

        protected abstract void VisitBranchOnGreaterThanOrEqualToShortInstruction(BranchOnGreaterThanOrEqualToShortInstruction instruction);

        protected abstract void VisitBranchOnGreaterThanOrEqualToUnsignedShortInstruction(BranchOnGreaterThanOrEqualToUnsignedShortInstruction instruction);

        protected abstract void VisitBranchOnLessThanShortInstruction(BranchOnLessThanShortInstruction instruction);

        protected abstract void VisitBranchOnLessThanUnsignedShortInstruction(BranchOnLessThanUnsignedShortInstruction instruction);

        protected abstract void VisitBranchOnLessThanOrEqualToShortInstruction(BranchOnLessThanOrEqualToShortInstruction instruction);

        protected abstract void VisitBranchOnLessThanOrEqualToUnsignedShortInstruction(BranchOnLessThanOrEqualToUnsignedShortInstruction instruction);

        protected abstract void VisitBranchOnNotEqualUnsignedShortInstruction(BranchOnNotEqualUnsignedShortInstruction instruction);

        protected abstract void VisitBranchOnTrueShortInstruction(BranchOnTrueShortInstruction instruction);
    }
}