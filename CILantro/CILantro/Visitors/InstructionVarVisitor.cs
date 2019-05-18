using CILantro.Instructions;
using CILantro.Instructions.Var;
using System;

namespace CILantro.Visitors
{
    public abstract class InstructionVarVisitor
    {
        public void VisitInstructionVar(CilInstructionVar instruction)
        {
            if (instruction is StoreLocalShortInstruction storeLocalShortInstruction)
                VisitStoreLocalShortInstruction(storeLocalShortInstruction);
            else if (instruction is LoadLocalShortInstruction loadLocalShortInstruction)
                VisitLoadLocalShortInstruction(loadLocalShortInstruction);
            else if (instruction is LoadLocalAddressShortInstruction loadLocalAddressShortInstruction)
                VisitLoadLocalAddressShortInstruction(loadLocalAddressShortInstruction);
            else if (instruction is LoadArgumentShortInstruction loadArgumentShortInstruction)
                VisitLoadArgumentShortInstruction(loadArgumentShortInstruction);
            else
                throw new ArgumentException($"CIL instruction none cannot be recognized: '{instruction.ToString()}'.");
        }

        protected abstract void VisitLoadArgumentShortInstruction(LoadArgumentShortInstruction instruction);

        protected abstract void VisitLoadLocalAddressShortInstruction(LoadLocalAddressShortInstruction instruction);

        protected abstract void VisitLoadLocalShortInstruction(LoadLocalShortInstruction instruction);

        protected abstract void VisitStoreLocalShortInstruction(StoreLocalShortInstruction instruction);
    }
}