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
            else if (instruction is LoadConstI41Instruction loadConstI41Instruction)
                VisitLoadConstI41Instruction(loadConstI41Instruction);
            else if (instruction is LoadConstI42Instruction loadConstI42Instruction)
                VisitLoadConstI42Instruction(loadConstI42Instruction);
            else if (instruction is LoadConstI43Instruction loadConstI43Instruction)
                VisitLoadConstI43Instruction(loadConstI43Instruction);
            else if (instruction is LoadConstI44Instruction loadConstI44Instruction)
                VisitLoadConstI44Instruction(loadConstI44Instruction);
            else if (instruction is LoadConstI45Instruction loadConstI45Instruction)
                VisitLoadConstI45Instruction(loadConstI45Instruction);
            else if (instruction is LoadConstI46Instruction loadConstI46Instruction)
                VisitLoadConstI46Instruction(loadConstI46Instruction);
            else if (instruction is LoadConstI47Instruction loadConstI47Instruction)
                VisitLoadConstI47Instruction(loadConstI47Instruction);
            else if (instruction is LoadConstI48Instruction loadConstI48Instruction)
                VisitLoadConstI48Instruction(loadConstI48Instruction);
            else if (instruction is LoadConstI4M1Instruction loadConstI4M1Instruction)
                VisitLoadConstI4M1Instruction(loadConstI4M1Instruction);
            else if (instruction is ReturnInstruction returnInstruction)
                VisitReturnInstruction(returnInstruction);
            else if (instruction is DuplicateInstruction duplicateInstruction)
                VisitDuplicateInstruction(duplicateInstruction);
            else if (instruction is StoreArrayElementI2Instruction storeArrayElementI2Instruction)
                VisitStoreArrayElementI2Instruction(storeArrayElementI2Instruction);
            else if (instruction is LoadArrayElementRefInstruction loadArrayElementRefInstruction)
                VisitLoadArrayElementRefInstruction(loadArrayElementRefInstruction);
            else if (instruction is StoreLocal0Instruction storeLocal0Instruction)
                VisitStoreLocal0Instruction(storeLocal0Instruction);
            else if (instruction is StoreLocal1Instruction storeLocal1Instruction)
                VisitStoreLocal1Instruction(storeLocal1Instruction);
            else if (instruction is LoadLocal0Instruction loadLocal0Instruction)
                VisitLoadLocal0Instruction(loadLocal0Instruction);
            else if (instruction is LoadLocal1Instruction loadLocal1Instruction)
                VisitLoadLocal1Instruction(loadLocal1Instruction);
            else if (instruction is AddInstruction addInstruction)
                VisitAddInstruction(addInstruction);
            else
                throw new ArgumentException($"CIL instruction none cannot be recognized: '{instruction.ToString()}'.");
        }

        protected abstract void VisitAddInstruction(AddInstruction instruction);

        protected abstract void VisitDuplicateInstruction(DuplicateInstruction instruction);

        protected abstract void VisitLoadArrayElementRefInstruction(LoadArrayElementRefInstruction instruction);

        protected abstract void VisitLoadConstI40Intruction(LoadConstI40Instruction instruction);

        protected abstract void VisitLoadConstI41Instruction(LoadConstI41Instruction instruction);

        protected abstract void VisitLoadConstI42Instruction(LoadConstI42Instruction instruction);

        protected abstract void VisitLoadConstI43Instruction(LoadConstI43Instruction instruction);

        protected abstract void VisitLoadConstI44Instruction(LoadConstI44Instruction instruction);

        protected abstract void VisitLoadConstI45Instruction(LoadConstI45Instruction instruction);

        protected abstract void VisitLoadConstI46Instruction(LoadConstI46Instruction instruction);

        protected abstract void VisitLoadConstI47Instruction(LoadConstI47Instruction instruction);

        protected abstract void VisitLoadConstI48Instruction(LoadConstI48Instruction instruction);

        protected abstract void VisitLoadConstI4M1Instruction(LoadConstI4M1Instruction instruction);

        protected abstract void VisitLoadLocal0Instruction(LoadLocal0Instruction instruction);

        protected abstract void VisitLoadLocal1Instruction(LoadLocal1Instruction instruction);

        protected abstract void VisitReturnInstruction(ReturnInstruction instruction);

        protected abstract void VisitStoreArrayElementI2Instruction(StoreArrayElementI2Instruction instruction);

        protected abstract void VisitStoreLocal0Instruction(StoreLocal0Instruction instruction);

        protected abstract void VisitStoreLocal1Instruction(StoreLocal1Instruction instruction);
    }
}