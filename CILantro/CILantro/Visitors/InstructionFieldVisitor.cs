using CILantro.Instructions;
using CILantro.Instructions.Field;
using System;

namespace CILantro.Visitors
{
    public abstract class InstructionFieldVisitor
    {
        public void VisitInstructionField(CilInstructionField instruction)
        {
            if (instruction is LoadStaticFieldInstruction loadStaticFieldInstruction)
                VisitLoadStaticFieldInstruction(loadStaticFieldInstruction);
            else if (instruction is StoreStaticFieldInstruction storeStaticFieldInstruction)
                VisitStoreStaticFieldInstruction(storeStaticFieldInstruction);
            else if (instruction is StoreFieldInstruction storeFieldInstruction)
                VisitStoreFieldInstruction(storeFieldInstruction);
            else if (instruction is LoadFieldInstruction loadFieldInstruction)
                VisitLoadFieldInstruction(loadFieldInstruction);
            else
                throw new ArgumentException($"CIL instruction field cannot be recognized: '{instruction.ToString()}'.");
        }

        protected abstract void VisitLoadFieldInstruction(LoadFieldInstruction instruction);

        protected abstract void VisitLoadStaticFieldInstruction(LoadStaticFieldInstruction instruction);

        protected abstract void VisitStoreFieldInstruction(StoreFieldInstruction instruction);

        protected abstract void VisitStoreStaticFieldInstruction(StoreStaticFieldInstruction instruction);
    }
}