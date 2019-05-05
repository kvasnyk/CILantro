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
            else if (instruction is StoreLocal2Instruction storeLocal2Instruction)
                VisitStoreLocal2Instruction(storeLocal2Instruction);
            else if (instruction is StoreLocal3Instruction storeLocal3Instruction)
                VisitStoreLocal3Instruction(storeLocal3Instruction);
            else if (instruction is LoadLocal0Instruction loadLocal0Instruction)
                VisitLoadLocal0Instruction(loadLocal0Instruction);
            else if (instruction is LoadLocal1Instruction loadLocal1Instruction)
                VisitLoadLocal1Instruction(loadLocal1Instruction);
            else if (instruction is LoadLocal2Instruction loadLocal2Instruction)
                VisitLoadLocal2Instruction(loadLocal2Instruction);
            else if (instruction is LoadLocal3Instruction loadLocal3Instruction)
                VisitLoadLocal3Instruction(loadLocal3Instruction);
            else if (instruction is AddInstruction addInstruction)
                VisitAddInstruction(addInstruction);
            else if (instruction is ConvertI8Instruction convertI8Instruction)
                VisitConvertI8Instruction(convertI8Instruction);
            else if (instruction is ConvertU8Instruction convertU8Instruction)
                VisitConvertU8Instruction(convertU8Instruction);
            else if (instruction is ConvertR4Instruction convertR4Instruction)
                VisitConvertR4Instruction(convertR4Instruction);
            else if (instruction is ConvertR8Instruction convertR8Instruction)
                VisitConvertR8Instruction(convertR8Instruction);
            else if (instruction is ConvertRUnsignedInstruction convertRUnsignedInstruction)
                VisitConvertRUnsignedInstruction(convertRUnsignedInstruction);
            else if (instruction is SubtractInstruction subtractInstruction)
                VisitSubtractInstruction(subtractInstruction);
            else if (instruction is ConvertI1Instruction convertI1Instruction)
                VisitConvertI1Instruction(convertI1Instruction);
            else if (instruction is ConvertI2Instruction convertI2Instruction)
                VisitConvertI2Instruction(convertI2Instruction);
            else if (instruction is ConvertU1Instruction convertU1Instruction)
                VisitConvertU1Instruction(convertU1Instruction);
            else if (instruction is ConvertU2Instruction convertU2Instruction)
                VisitConvertU2Instruction(convertU2Instruction);
            else if (instruction is MultiplyInstruction multiplyInstruction)
                VisitMultiplyInstruction(multiplyInstruction);
            else if (instruction is DivideInstruction divideInstruction)
                VisitDivideInstruction(divideInstruction);
            else if (instruction is DivideUnsignedInstruction divideUnsignedInstruction)
                VisitDivideUnsignedInstruction(divideUnsignedInstruction);
            else if (instruction is RemainderInstruction remainderInstruction)
                VisitRemainderInstruction(remainderInstruction);
            else if (instruction is RemainderUnsignedInstruction remainderUnsignedInstruction)
                VisitRemainderUnsignedInstruction(remainderUnsignedInstruction);
            else if (instruction is CompareEqualInstruction compareEqualInstruction)
                VisitCompareEqualInstruction(compareEqualInstruction);
            else if (instruction is CompareGreaterThanInstruction compareGreaterThanInstruction)
                VisitCompareGreaterThanInstruction(compareGreaterThanInstruction);
            else if (instruction is CompareGreaterThanUnsignedInstruction compareGreaterThanUnsignedInstruction)
                VisitCompareGreaterThanUnsignedInstruction(compareGreaterThanUnsignedInstruction);
            else if (instruction is CompareLessThanInstruction compareLessThanInstruction)
                VisitCompareLessThanInstruction(compareLessThanInstruction);
            else if (instruction is CompareLessThanUnsignedInstruction compareLessThanUnsignedInstruction)
                VisitCompareLessThanUnsignedInstruction(compareLessThanUnsignedInstruction);
            else if (instruction is AndInstruction andInstruction)
                VisitAndInstruction(andInstruction);
            else if (instruction is OrInstruction orInstruction)
                VisitOrInstruction(orInstruction);
            else if (instruction is PopInstruction popInstruction)
                VisitPopInstruction(popInstruction);
            else if (instruction is XorInstruction xorInstruction)
                VisitXorInstruction(xorInstruction);
            else if (instruction is ShiftLeftInstruction shiftLeftInstruction)
                VisitShiftLeftInstruction(shiftLeftInstruction);
            else if (instruction is ShiftRightInstruction shiftRightInstruction)
                VisitShiftRightInstruction(shiftRightInstruction);
            else if (instruction is ShiftRightUnsignedInstruction shiftRightUnsignedInstruction)
                VisitShiftRightUnsignedInstruction(shiftRightUnsignedInstruction);
            else
                throw new ArgumentException($"CIL instruction none cannot be recognized: '{instruction.ToString()}'.");
        }

        protected abstract void VisitAddInstruction(AddInstruction instruction);

        protected abstract void VisitAndInstruction(AndInstruction instruction);

        protected abstract void VisitCompareEqualInstruction(CompareEqualInstruction instruction);

        protected abstract void VisitCompareGreaterThanInstruction(CompareGreaterThanInstruction instruction);

        protected abstract void VisitCompareGreaterThanUnsignedInstruction(CompareGreaterThanUnsignedInstruction instruction);

        protected abstract void VisitCompareLessThanInstruction(CompareLessThanInstruction instruction);

        protected abstract void VisitCompareLessThanUnsignedInstruction(CompareLessThanUnsignedInstruction instruction);

        protected abstract void VisitConvertI1Instruction(ConvertI1Instruction instruction);

        protected abstract void VisitConvertI2Instruction(ConvertI2Instruction instruction);

        protected abstract void VisitConvertI8Instruction(ConvertI8Instruction instruction);

        protected abstract void VisitConvertR4Instruction(ConvertR4Instruction instruction);

        protected abstract void VisitConvertR8Instruction(ConvertR8Instruction instruction);

        protected abstract void VisitConvertRUnsignedInstruction(ConvertRUnsignedInstruction instruction);

        protected abstract void VisitConvertU1Instruction(ConvertU1Instruction instruction);

        protected abstract void VisitConvertU2Instruction(ConvertU2Instruction instruction);

        protected abstract void VisitConvertU8Instruction(ConvertU8Instruction instruction);

        protected abstract void VisitDivideInstruction(DivideInstruction instruction);

        protected abstract void VisitDivideUnsignedInstruction(DivideUnsignedInstruction instruction);

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

        protected abstract void VisitLoadLocal2Instruction(LoadLocal2Instruction instruction);

        protected abstract void VisitLoadLocal3Instruction(LoadLocal3Instruction instruction);

        protected abstract void VisitMultiplyInstruction(MultiplyInstruction instruction);

        protected abstract void VisitOrInstruction(OrInstruction instruction);

        protected abstract void VisitPopInstruction(PopInstruction instruction);

        protected abstract void VisitRemainderInstruction(RemainderInstruction instruction);

        protected abstract void VisitRemainderUnsignedInstruction(RemainderUnsignedInstruction instruction);

        protected abstract void VisitReturnInstruction(ReturnInstruction instruction);

        protected abstract void VisitShiftLeftInstruction(ShiftLeftInstruction instruction);

        protected abstract void VisitShiftRightInstruction(ShiftRightInstruction instruction);

        protected abstract void VisitShiftRightUnsignedInstruction(ShiftRightUnsignedInstruction instruction);

        protected abstract void VisitStoreArrayElementI2Instruction(StoreArrayElementI2Instruction instruction);

        protected abstract void VisitStoreLocal0Instruction(StoreLocal0Instruction instruction);

        protected abstract void VisitStoreLocal1Instruction(StoreLocal1Instruction instruction);

        protected abstract void VisitStoreLocal2Instruction(StoreLocal2Instruction instruction);

        protected abstract void VisitStoreLocal3Instruction(StoreLocal3Instruction instruction);

        protected abstract void VisitSubtractInstruction(SubtractInstruction instruction);

        protected abstract void VisitXorInstruction(XorInstruction instruction);
    }
}