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
            else
                throw new ArgumentException($"CIL instruction field cannot be recognized: '{instruction.ToString()}'.");
        }

        protected abstract void VisitLoadStaticFieldInstruction(LoadStaticFieldInstruction instruction);

        protected abstract void VisitStoreStaticFieldInstruction(StoreStaticFieldInstruction instruction);
    }
}