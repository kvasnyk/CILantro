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
            else if (instruction is BranchOnTrueInstruction branchOnTrueInstruction)
                VisitBranchOnTrueInstruction(branchOnTrueInstruction);
            else if (instruction is BranchOnFalseShortInstruction branchOnFalseShortInstruction)
                VisitBranchOnFalseShortInstruction(branchOnFalseShortInstruction);
            else if (instruction is BranchOnFalseInstruction branchOnFalseInstruction)
                VisitBranchOnFalseInstruction(branchOnFalseInstruction);
            else if (instruction is BranchShortInstruction branchShortInstruction)
                VisitBranchShortInstruction(branchShortInstruction);
            else if (instruction is BranchOnNotEqualUnsignedShortInstruction branchOnNotEqualUnsignedShortInstruction)
                VisitBranchOnNotEqualUnsignedShortInstruction(branchOnNotEqualUnsignedShortInstruction);
            else if (instruction is BranchOnNotEqualUnsignedInstruction branchOnNotEqualUnsignedInstruction)
                VisitBranchOnNotEqualUnsignedInstruction(branchOnNotEqualUnsignedInstruction);
            else if (instruction is BranchOnEqualShortInstruction branchOnEqualShortInstruction)
                VisitBranchOnEqualShortInstruction(branchOnEqualShortInstruction);
            else if (instruction is BranchOnEqualInstruction branchOnEqualInstruction)
                VisitBranchOnEqualInstruction(branchOnEqualInstruction);
            else if (instruction is BranchOnLessThanOrEqualToShortInstruction branchOnLessThanOrEqualToShortInstruction)
                VisitBranchOnLessThanOrEqualToShortInstruction(branchOnLessThanOrEqualToShortInstruction);
            else if (instruction is BranchOnLessThanOrEqualToInstruction branchOnLessThanOrEqualToInstruction)
                VisitBranchOnLessThanOrEqualToInstruction(branchOnLessThanOrEqualToInstruction);
            else if (instruction is BranchOnLessThanOrEqualToUnsignedShortInstruction branchOnLessThanOrEqualToUnsignedShortInstruction)
                VisitBranchOnLessThanOrEqualToUnsignedShortInstruction(branchOnLessThanOrEqualToUnsignedShortInstruction);
            else if (instruction is BranchOnLessThanOrEqualToUnsignedInstruction branchOnLessThanOrEqualToUnsignedInstruction)
                VisitBranchOnLessThanOrEqualToUnsignedInstruction(branchOnLessThanOrEqualToUnsignedInstruction);
            else if (instruction is BranchOnLessThanShortInstruction branchOnLessThanShortInstruction)
                VisitBranchOnLessThanShortInstruction(branchOnLessThanShortInstruction);
            else if (instruction is BranchOnLessThanInstruction branchOnLessThanInstruction)
                VisitBranchOnLessThanInstruction(branchOnLessThanInstruction);
            else if (instruction is BranchOnLessThanUnsignedShortInstruction branchOnLessThanUnsignedShortInstruction)
                VisitBranchOnLessThanUnsignedShortInstruction(branchOnLessThanUnsignedShortInstruction);
            else if (instruction is BranchOnLessThanUnsignedInstruction branchOnLessThanUnsignedInstruction)
                VisitBranchOnLessThanUnsignedInstruction(branchOnLessThanUnsignedInstruction);
            else if (instruction is BranchOnGreaterThanOrEqualToShortInstruction branchOnGreaterThanOrEqualToShortInstruction)
                VisitBranchOnGreaterThanOrEqualToShortInstruction(branchOnGreaterThanOrEqualToShortInstruction);
            else if (instruction is BranchOnGreaterThanOrEqualToInstruction branchOnGreaterThanOrEqualToInstruction)
                VisitBranchOnGreaterThanOrEqualToInstruction(branchOnGreaterThanOrEqualToInstruction);
            else if (instruction is BranchOnGreaterThanOrEqualToUnsignedShortInstruction branchOnGreaterThanOrEqualToUnsignedShortInstruction)
                VisitBranchOnGreaterThanOrEqualToUnsignedShortInstruction(branchOnGreaterThanOrEqualToUnsignedShortInstruction);
            else if (instruction is BranchOnGreaterThanOrEqualToUnsignedInstruction branchOnGreaterThanOrEqualToUnsignedInstruction)
                VisitBranchOnGreaterThanOrEqualToUnsignedInstruction(branchOnGreaterThanOrEqualToUnsignedInstruction);
            else if (instruction is BranchOnGreaterThanShortInstruction branchOnGreaterThanShortInstruction)
                VisitBranchOnGreaterThanShortInstruction(branchOnGreaterThanShortInstruction);
            else if (instruction is BranchOnGreaterThanInstruction branchOnGreaterThanInstruction)
                VisitBranchOnGreaterThanInstruction(branchOnGreaterThanInstruction);
            else if (instruction is BranchOnGreaterThanUnsignedShortInstruction branchOnGreaterThanUnsignedShortInstruction)
                VisitBranchOnGreaterThanUnsignedShortInstruction(branchOnGreaterThanUnsignedShortInstruction);
            else if (instruction is BranchOnGreaterThanUnsignedInstruction branchOnGreaterThanUnsignedInstruction)
                VisitBranchOnGreaterThanUnsignedInstruction(branchOnGreaterThanUnsignedInstruction);
            else if (instruction is BranchInstruction branchInstruction)
                VisitBranchInstruction(branchInstruction);
            else
                throw new ArgumentException($"CIL instruction br cannot be recognized: '{instruction.ToString()}'.");
        }

        protected abstract void VisitBranchInstruction(BranchInstruction instruction);

        protected abstract void VisitBranchShortInstruction(BranchShortInstruction instruction);

        protected abstract void VisitBranchOnEqualShortInstruction(BranchOnEqualShortInstruction instruction);

        protected abstract void VisitBranchOnEqualInstruction(BranchOnEqualInstruction instruction);

        protected abstract void VisitBranchOnFalseShortInstruction(BranchOnFalseShortInstruction instruction);

        protected abstract void VisitBranchOnFalseInstruction(BranchOnFalseInstruction instruction);

        protected abstract void VisitBranchOnGreaterThanShortInstruction(BranchOnGreaterThanShortInstruction instruction);

        protected abstract void VisitBranchOnGreaterThanInstruction(BranchOnGreaterThanInstruction instruction);

        protected abstract void VisitBranchOnGreaterThanUnsignedShortInstruction(BranchOnGreaterThanUnsignedShortInstruction instruction);

        protected abstract void VisitBranchOnGreaterThanUnsignedInstruction(BranchOnGreaterThanUnsignedInstruction instruction);

        protected abstract void VisitBranchOnGreaterThanOrEqualToShortInstruction(BranchOnGreaterThanOrEqualToShortInstruction instruction);

        protected abstract void VisitBranchOnGreaterThanOrEqualToInstruction(BranchOnGreaterThanOrEqualToInstruction instruction);

        protected abstract void VisitBranchOnGreaterThanOrEqualToUnsignedShortInstruction(BranchOnGreaterThanOrEqualToUnsignedShortInstruction instruction);

        protected abstract void VisitBranchOnGreaterThanOrEqualToUnsignedInstruction(BranchOnGreaterThanOrEqualToUnsignedInstruction instruction);

        protected abstract void VisitBranchOnLessThanShortInstruction(BranchOnLessThanShortInstruction instruction);

        protected abstract void VisitBranchOnLessThanInstruction(BranchOnLessThanInstruction instruction);

        protected abstract void VisitBranchOnLessThanUnsignedShortInstruction(BranchOnLessThanUnsignedShortInstruction instruction);

        protected abstract void VisitBranchOnLessThanUnsignedInstruction(BranchOnLessThanUnsignedInstruction instruction);

        protected abstract void VisitBranchOnLessThanOrEqualToShortInstruction(BranchOnLessThanOrEqualToShortInstruction instruction);

        protected abstract void VisitBranchOnLessThanOrEqualToInstruction(BranchOnLessThanOrEqualToInstruction instruction);

        protected abstract void VisitBranchOnLessThanOrEqualToUnsignedShortInstruction(BranchOnLessThanOrEqualToUnsignedShortInstruction instruction);

        protected abstract void VisitBranchOnLessThanOrEqualToUnsignedInstruction(BranchOnLessThanOrEqualToUnsignedInstruction instruction);

        protected abstract void VisitBranchOnNotEqualUnsignedShortInstruction(BranchOnNotEqualUnsignedShortInstruction instruction);

        protected abstract void VisitBranchOnNotEqualUnsignedInstruction(BranchOnNotEqualUnsignedInstruction instruction);

        protected abstract void VisitBranchOnTrueShortInstruction(BranchOnTrueShortInstruction instruction);

        protected abstract void VisitBranchOnTrueInstruction(BranchOnTrueInstruction instruction);
    }
}