using CILantro.Instructions.None;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.StackValues;
using CILantro.Interpreting.State;
using CILantro.Interpreting.Types;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using CILantro.Visitors;
using System;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionNoneInterpreterVisitor : InstructionNoneVisitor
    {
        private readonly CilControlState _state;

        private readonly CilManagedMemory _managedMemory;

        private readonly CilProgram _program;

        public InstructionNoneInterpreterVisitor(CilProgram program, CilControlState state, CilManagedMemory managedMemory)
        {
            _state = state;
            _managedMemory = managedMemory;
            _program = program;
        }

        protected override void VisitAddInstruction(AddInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryNumericOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value + b.Value),
                (a, b) => new CilStackValueInt64(a.Value + b.Value),
                (a, b) => new CilStackValueFloat(a.Value + b.Value)
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitAndInstruction(AndInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeIntegerOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value & b.Value),
                (a, b) => new CilStackValueInt64(a.Value & b.Value)
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitCompareEqualInstruction(CompareEqualInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryComparisonOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.Value == b.Value,
                (a, b) => a.Value == b.Value,
                (a, b) => a.Value == b.Value
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitCompareGreaterThanInstruction(CompareGreaterThanInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryComparisonOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.Value > b.Value,
                (a, b) => a.Value > b.Value,
                (a, b) => a.Value > b.Value
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitCompareGreaterThanUnsignedInstruction(CompareGreaterThanUnsignedInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryComparisonOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.ValueUnsigned > b.ValueUnsigned,
                (a, b) => a.ValueUnsigned > b.ValueUnsigned,
                (a, b) => a.Value > b.Value
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitCompareLessThanInstruction(CompareLessThanInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryComparisonOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.Value < b.Value,
                (a, b) => a.Value < b.Value,
                (a, b) => a.Value < b.Value
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitCompareLessThanUnsignedInstruction(CompareLessThanUnsignedInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryComparisonOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.ValueUnsigned < b.ValueUnsigned,
                (a, b) => a.ValueUnsigned < b.ValueUnsigned,
                (a, b) => a.Value < b.Value
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitConvertI1Instruction(ConvertI1Instruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => new CilStackValueInt32((sbyte)x.Value),
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); }
            );
            _state.EvaluationStack.Push(newStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitConvertI2Instruction(ConvertI2Instruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => new CilStackValueInt32((short)x.Value),
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); }
            );
            _state.EvaluationStack.Push(newStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitConvertI8Instruction(ConvertI8Instruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => new CilStackValueInt64(x.Value),
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); }
            );
            _state.EvaluationStack.Push(newStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitConvertR4Instruction(ConvertR4Instruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => new CilStackValueFloat((float)x.Value),
                x => new CilStackValueFloat((float)x.Value),
                x => new CilStackValueFloat((float)x.Value),
                x => { throw new NotImplementedException(); }
            );
            _state.EvaluationStack.Push(newStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitConvertR8Instruction(ConvertR8Instruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => new CilStackValueFloat((double)x.Value),
                x => new CilStackValueFloat((double)x.Value),
                x => new CilStackValueFloat(x.Value),
                x => { throw new NotImplementedException(); }
            );
            _state.EvaluationStack.Push(newStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitConvertRUnsignedInstruction(ConvertRUnsignedInstruction instruction)
        {
            // TODO: finish implementation
            // TODO: should we deal with the fact it is unsigned instruction?

            _state.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => new CilStackValueFloat((double)x.ValueUnsigned),
                x => new CilStackValueFloat((double)x.ValueUnsigned),
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); }
            );
            _state.EvaluationStack.Push(newStackVal);

            _state.MoveToNextInstruction();
        }

        protected unsafe override void VisitConvertUInstruction(ConvertUInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => new CilStackValueNativeInt(x.ValueToRef.GetPointerValue())
            );
            _state.EvaluationStack.Push(newStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitConvertU1Instruction(ConvertU1Instruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => new CilStackValueInt32((byte)x.ValueUnsigned),
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); }
            );
            _state.EvaluationStack.Push(newStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitConvertU2Instruction(ConvertU2Instruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => new CilStackValueInt32((ushort)x.ValueUnsigned),
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); }
            );
            _state.EvaluationStack.Push(newStackVal);

            _state.MoveToNextInstruction(); ;
        }

        protected override void VisitConvertU8Instruction(ConvertU8Instruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => new CilStackValueInt64((long)(ulong)x.ValueUnsigned),
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); }
            );
            _state.EvaluationStack.Push(newStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitDivideInstruction(DivideInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryNumericOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value / b.Value),
                (a, b) => new CilStackValueInt64(a.Value / b.Value),
                (a, b) => new CilStackValueFloat(a.Value / b.Value)
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitDivideUnsignedInstruction(DivideUnsignedInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeIntegerOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32((int)(a.ValueUnsigned / b.ValueUnsigned)),
                (a, b) => new CilStackValueInt64((long)(a.ValueUnsigned / b.ValueUnsigned))
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitDuplicateInstruction(DuplicateInstruction instruction)
        {
            _state.EvaluationStack.Pop(out var value);

            _state.EvaluationStack.Push(value);
            _state.EvaluationStack.Push(value);

            _state.MoveToNextInstruction();
        }

        protected unsafe override void VisitIndirectLoadI4Instruction(IndirectLoadI4Instruction instruction)
        {
            _state.EvaluationStack.PopValue(out CilValueManagedPointer valuePointer);

            _state.EvaluationStack.PushValue(valuePointer.ValueToRef);

            _state.MoveToNextInstruction();
        }

        protected override void VisitIndirectStoreI4Instruction(IndirectStoreI4Instruction instruction)
        {
            _state.EvaluationStack.PopValue(out CilValueManagedPointer pointer, out CilValueInt32 value);

            var int32PointerValue = pointer.ValueToRef as CilValueInt32;
            int32PointerValue.Value = value.Value;

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadArgument0Instruction(LoadArgument0Instruction instruction)
        {
            // TODO: finish implementation

            var value = _state.Arguments.Load(null, 0);
            _state.EvaluationStack.PushValue(value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadArgument1Instruction(LoadArgument1Instruction instruction)
        {
            // TODO: finish implementation

            var value = _state.Arguments.Load(null, 1);
            _state.EvaluationStack.PushValue(value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadArgument2Instruction(LoadArgument2Instruction instruction)
        {
            // TODO: finish implementation

            var value = _state.Arguments.Load(null, 2);
            _state.EvaluationStack.PushValue(value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadArgument3Instruction(LoadArgument3Instruction instruction)
        {
            // TODO: finish implementation

            var value = _state.Arguments.Load(null, 3);
            _state.EvaluationStack.PushValue(value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementI1Instruction(LoadArrayElementI1Instruction instruction)
        {
            // TODO: finish implementation
            // TODO: should we convert value from array to stack?

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, new CilTypeInt8(), _managedMemory, _program);

            _state.EvaluationStack.PushValue(elem);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementI2Instruction(LoadArrayElementI2Instruction instruction)
        {
            // TODO: finish implementation
            // TODO: should we convert value from array to stack?

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, new CilTypeInt16(), _managedMemory, _program);

            _state.EvaluationStack.PushValue(elem);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementI4Instruction(LoadArrayElementI4Instruction instruction)
        {
            // TODO: finish implementation
            // TODO: should we convert value from array to stack?

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, new CilTypeInt32(), _managedMemory, _program);

            _state.EvaluationStack.PushValue(elem);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementI8Instruction(LoadArrayElementI8Instruction instruction)
        {
            // TODO: finish implementation
            // TODO: should we convert value from array to stack?

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, new CilTypeInt64(), _managedMemory, _program);

            _state.EvaluationStack.PushValue(elem);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementR4Instruction(LoadArrayElementR4Instruction instruction)
        {
            // TODO: finish implementation
            // TODO: should we convert value from array to stack?

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, new CilTypeFloat32(), _managedMemory, _program);

            _state.EvaluationStack.PushValue(elem);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementR8Instruction(LoadArrayElementR8Instruction instruction)
        {
            // TODO: finish implementation
            // TODO: should we convert value from array to stack?

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, new CilTypeFloat64(), _managedMemory, _program);

            _state.EvaluationStack.PushValue(elem);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementRefInstruction(LoadArrayElementRefInstruction instruction)
        {
            // TODO: finish implementation
            // TODO: should we convert value from array to stack?

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, null, _managedMemory, _program);

            _state.EvaluationStack.PushValue(elem);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementU1Instruction(LoadArrayElementU1Instruction instruction)
        {
            // TODO: finish implementation
            // TODO: should we convert value from array to stack?

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, new CilTypeUInt8(), _managedMemory, _program);

            _state.EvaluationStack.PushValue(elem);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementU2Instruction(LoadArrayElementU2Instruction instruction)
        {
            // TODO: finish implementation
            // TODO: should we convert value from array to stack?

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, new CilTypeUInt16(), _managedMemory, _program);

            _state.EvaluationStack.PushValue(elem);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementU4Instruction(LoadArrayElementU4Instruction instruction)
        {
            // TODO: finish implementation
            // TODO: should we convert value from array to stack?

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, new CilTypeUInt32(), _managedMemory, _program);

            _state.EvaluationStack.PushValue(elem);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI40Intruction(LoadConstI40Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(0);
            _state.EvaluationStack.Push(stackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI41Instruction(LoadConstI41Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(1);
            _state.EvaluationStack.Push(stackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI42Instruction(LoadConstI42Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(2);
            _state.EvaluationStack.Push(stackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI43Instruction(LoadConstI43Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(3);
            _state.EvaluationStack.Push(stackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI44Instruction(LoadConstI44Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(4);
            _state.EvaluationStack.Push(stackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI45Instruction(LoadConstI45Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(5);
            _state.EvaluationStack.Push(stackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI46Instruction(LoadConstI46Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(6);
            _state.EvaluationStack.Push(stackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI47Instruction(LoadConstI47Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(7);
            _state.EvaluationStack.Push(stackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI48Instruction(LoadConstI48Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(8);
            _state.EvaluationStack.Push(stackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI4M1Instruction(LoadConstI4M1Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(-1);
            _state.EvaluationStack.Push(stackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadLocal0Instruction(LoadLocal0Instruction instruction)
        {
            // TODO: finish implementation

            var value = _state.Locals.Load(null, 0);
            _state.EvaluationStack.PushValue(value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadLocal1Instruction(LoadLocal1Instruction instruction)
        {
            // TODO: finish implementation

            var value = _state.Locals.Load(null, 1);
            _state.EvaluationStack.PushValue(value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadLocal2Instruction(LoadLocal2Instruction instruction)
        {
            // TODO: finish implementation

            var value = _state.Locals.Load(null, 2);
            _state.EvaluationStack.PushValue(value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadLocal3Instruction(LoadLocal3Instruction instruction)
        {
            // TODO: finish implementation

            var value = _state.Locals.Load(null, 3);
            _state.EvaluationStack.PushValue(value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitMultiplyInstruction(MultiplyInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryNumericOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value * b.Value),
                (a, b) => new CilStackValueInt64(a.Value * b.Value),
                (a, b) => new CilStackValueFloat(a.Value * b.Value)
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitNegateInstruction(NegateInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal);
            var resultStackVal = ComputeUnaryNumericOperation(
                stackVal,
                a => new CilStackValueInt32(-a.Value),
                a => new CilStackValueInt64(-a.Value),
                a => new CilStackValueFloat(-a.Value)
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitNotInstruction(NotInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal);
            var resultStackVal = ComputeUnaryIntegerOperation(
                stackVal,
                a => new CilStackValueInt32(~a.Value),
                a => new CilStackValueInt64(~a.Value)
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitOrInstruction(OrInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeIntegerOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value | b.Value),
                (a, b) => new CilStackValueInt64(a.Value | b.Value)
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitPopInstruction(PopInstruction instruction)
        {
            var stackValue = _state.EvaluationStack.Pop();

            _state.MoveToNextInstruction();
        }

        protected override void VisitRemainderInstruction(RemainderInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryNumericOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value % b.Value),
                (a, b) => new CilStackValueInt64(a.Value % b.Value),
                (a, b) => new CilStackValueFloat(a.Value % b.Value)
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitRemainderUnsignedInstruction(RemainderUnsignedInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeIntegerOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32((int)(a.ValueUnsigned % b.ValueUnsigned)),
                (a, b) => new CilStackValueInt64((long)(a.ValueUnsigned % b.ValueUnsigned))
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitReturnInstruction(ReturnInstruction instruction)
        {
            var currentMethodState = _state.CallStack.Pop();

            if (currentMethodState.EvaluationStack.IsEmpty)
            {
            }
            else
            {
                if (_state.CallStack.Count == 0)
                {
                    currentMethodState.EvaluationStack.PopValue(out CilValueInt32 value);
                    _state.ProgramResult = value.Value;
                }
                else
                {
                    if (currentMethodState.MethodInfo.IsConstructor)
                    {
                        currentMethodState.EvaluationStack.Pop(out var stackThisRef);
                        _state.EvaluationStack.Push(stackThisRef);
                    }
                    else
                    {
                        currentMethodState.EvaluationStack.PopValue(_program, currentMethodState.MethodInfo.ReturnType, out var value);
                        _state.EvaluationStack.PushValue(value);
                    }
                }

                if (!currentMethodState.EvaluationStack.IsEmpty)
                    throw new Exception("The evaluation stack is not empty!");
            }
        }

        protected override void VisitShiftLeftInstruction(ShiftLeftInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeShiftOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value << b.Value),
                (a, b) => new CilStackValueInt64(a.Value << b.Value)
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitShiftRightInstruction(ShiftRightInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeShiftOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value >> b.Value),
                (a, b) => new CilStackValueInt64(a.Value >> b.Value)
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitShiftRightUnsignedInstruction(ShiftRightUnsignedInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeShiftOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32((int)(a.ValueUnsigned >> b.Value)),
                (a, b) => new CilStackValueInt64((long)(a.ValueUnsigned >> b.Value))
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreArrayElementI1Instruction(StoreArrayElementI1Instruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal, out CilValueInt8 valueVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            array.SetValue(valueVal, indexVal, _managedMemory);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreArrayElementI2Instruction(StoreArrayElementI2Instruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal, out CilValueInt16 valueVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            array.SetValue(valueVal, indexVal, _managedMemory);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreArrayElementI4Instruction(StoreArrayElementI4Instruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal, out CilValueInt32 valueVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            array.SetValue(valueVal, indexVal, _managedMemory);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreArrayElementI8Instruction(StoreArrayElementI8Instruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal, out CilValueInt64 valueVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            array.SetValue(valueVal, indexVal, _managedMemory);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreArrayElementR4Instruction(StoreArrayElementR4Instruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal, out CilValueFloat32 valueVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            array.SetValue(valueVal, indexVal, _managedMemory);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreArrayElementR8Instruction(StoreArrayElementR8Instruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal, out CilValueFloat64 valueVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            array.SetValue(valueVal, indexVal, _managedMemory);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreArrayElementRefInstruction(StoreArrayElementRefInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal, out CilValueReference valueVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            array.SetValue(valueVal, indexVal, _managedMemory);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreLocal0Instruction(StoreLocal0Instruction instruction)
        {
            var localType = _state.Locals.GetLocalType(null, 0);
            _state.EvaluationStack.PopValue(_program, localType, out var value);
            _state.Locals.Store(null, 0, value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreLocal1Instruction(StoreLocal1Instruction instruction)
        {
            var localType = _state.Locals.GetLocalType(null, 1);
            _state.EvaluationStack.PopValue(_program, localType, out var value);
            _state.Locals.Store(null, 1, value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreLocal2Instruction(StoreLocal2Instruction instruction)
        {
            var localType = _state.Locals.GetLocalType(null, 2);
            _state.EvaluationStack.PopValue(_program, localType, out var value);
            _state.Locals.Store(null, 2, value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreLocal3Instruction(StoreLocal3Instruction instruction)
        {
            var localType = _state.Locals.GetLocalType(null, 3);
            _state.EvaluationStack.PopValue(_program, localType, out var value);
            _state.Locals.Store(null, 3, value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitSubtractInstruction(SubtractInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryNumericOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value - b.Value),
                (a, b) => new CilStackValueInt64(a.Value - b.Value),
                (a, b) => new CilStackValueFloat(a.Value - b.Value)
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitXorInstruction(XorInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeIntegerOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value ^ b.Value),
                (a, b) => new CilStackValueInt64(a.Value ^ b.Value)
            );
            _state.EvaluationStack.Push(resultStackVal);

            _state.MoveToNextInstruction();
        }

        private IStackValue ComputeUnaryNumericOperation(
            IStackValue stackVal,
            Func<CilStackValueInt32, CilStackValueInt32> computeInt32,
            Func<CilStackValueInt64, CilStackValueInt64> computeInt64,
            Func<CilStackValueFloat, CilStackValueFloat> computeFloat
        )
        {
            // TODO: cover all cases

            if (stackVal is CilStackValueInt32 stackValInt32)
                return computeInt32(stackValInt32);
            if (stackVal is CilStackValueInt64 stackValInt64)
                return computeInt64(stackValInt64);
            if (stackVal is CilStackValueFloat stackValFloat)
                return computeFloat(stackValFloat);

            throw new System.NotImplementedException();
        }

        private IStackValue ComputeBinaryNumericOperation(
            IStackValue stackVal1,
            IStackValue stackVal2,
            Func<CilStackValueInt32, CilStackValueInt32, CilStackValueInt32> computeInt32Int32,
            Func<CilStackValueInt64, CilStackValueInt64, CilStackValueInt64> computeInt64Int64,
            Func<CilStackValueFloat, CilStackValueFloat, CilStackValueFloat> computeFloatFloat
        )
        {
            // TODO: cover all cases

            if (stackVal1 is CilStackValueInt32 stackVal1Int32 && stackVal2 is CilStackValueInt32 stackVal2Int32)
                return computeInt32Int32(stackVal1Int32, stackVal2Int32);
            if (stackVal1 is CilStackValueInt64 stackVal1Int64 && stackVal2 is CilStackValueInt64 stackVal2Int64)
                return computeInt64Int64(stackVal1Int64, stackVal2Int64);
            if (stackVal1 is CilStackValueFloat stackVal1Float && stackVal2 is CilStackValueFloat stackVal2Float)
                return computeFloatFloat(stackVal1Float, stackVal2Float);

            throw new System.NotImplementedException();
        }

        private CilStackValueInt32 ComputeBinaryComparisonOperation(
            IStackValue stackVal1,
            IStackValue stackVal2,
            Func<CilStackValueInt32, CilStackValueInt32, bool> computeInt32Int32,
            Func<CilStackValueInt64, CilStackValueInt64, bool> computeInt64Int64,
            Func<CilStackValueFloat, CilStackValueFloat, bool> computeFloatFloat
        )
        {
            // TODO: cover all cases

            bool result;

            if (stackVal1 is CilStackValueInt32 stackVal1Int32 && stackVal2 is CilStackValueInt32 stackVal2Int32)
                result = computeInt32Int32(stackVal1Int32, stackVal2Int32);
            else if (stackVal1 is CilStackValueInt64 stackVal1Int64 && stackVal2 is CilStackValueInt64 stackVal2Int64)
                result = computeInt64Int64(stackVal1Int64, stackVal2Int64);
            else if (stackVal1 is CilStackValueFloat stackVal1Float && stackVal2 is CilStackValueFloat stackVal2Float)
                result = computeFloatFloat(stackVal1Float, stackVal2Float);
            else
                throw new System.NotImplementedException();

            if (result) return new CilStackValueInt32(1);
            else return new CilStackValueInt32(0);
        }

        private IStackValue ComputeConversionOperation(
            IStackValue stackVal,
            Func<CilStackValueInt32, IStackValue> computeInt32,
            Func<CilStackValueInt64, IStackValue> computeInt64,
            Func<CilStackValueFloat, IStackValue> computeFloat,
            Func<CilStackValuePointer, IStackValue> computePointer
        )
        {
            // TODO: cover all cases

            if (stackVal is CilStackValueInt32 stackValInt32)
                return computeInt32(stackValInt32);
            if (stackVal is CilStackValueInt64 stackValInt64)
                return computeInt64(stackValInt64);
            if (stackVal is CilStackValueFloat stackValFloat)
                return computeFloat(stackValFloat);
            if (stackVal is CilStackValuePointer stackValPointer)
                return computePointer(stackValPointer);

            throw new System.NotImplementedException();
        }

        private IStackValue ComputeUnaryIntegerOperation(
            IStackValue stackVal,
            Func<CilStackValueInt32, CilStackValueInt32> computeInt32,
            Func<CilStackValueInt64, CilStackValueInt64> computeInt64
        )
        {
            // TODO: cover all cases

            if (stackVal is CilStackValueInt32 stackValInt32)
                return computeInt32(stackValInt32);
            if (stackVal is CilStackValueInt64 stackValInt64)
                return computeInt64(stackValInt64);

            throw new System.NotImplementedException();
        }

        private IStackValue ComputeIntegerOperation(
            IStackValue stackVal1,
            IStackValue stackVal2,
            Func<CilStackValueInt32, CilStackValueInt32, CilStackValueInt32> computeInt32Int32,
            Func<CilStackValueInt64, CilStackValueInt64, CilStackValueInt64> computeInt64Int64
        )
        {
            // TODO: cover all cases

            if (stackVal1 is CilStackValueInt32 stackVal1Int32 && stackVal2 is CilStackValueInt32 stackVal2Int32)
                return computeInt32Int32(stackVal1Int32, stackVal2Int32);
            if (stackVal1 is CilStackValueInt64 stackVal1Int64 && stackVal2 is CilStackValueInt64 stackVal2Int64)
                return computeInt64Int64(stackVal1Int64, stackVal2Int64);

            throw new System.NotImplementedException();
        }

        private IStackValue ComputeShiftOperation(
            IStackValue stackVal1,
            IStackValue stackVal2,
            Func<CilStackValueInt32, CilStackValueInt32, CilStackValueInt32> computeInt32Int32,
            Func<CilStackValueInt64, CilStackValueInt32, CilStackValueInt64> computeInt64Int32
        )
        {
            // TODO: cover all cases

            if (stackVal1 is CilStackValueInt32 stackVal1Int32 && stackVal2 is CilStackValueInt32 stackVal2Int32)
                return computeInt32Int32(stackVal1Int32, stackVal2Int32);
            if (stackVal1 is CilStackValueInt64 stackVal1Int64 && stackVal2 is CilStackValueInt32 stackVal2Int32_2)
                return computeInt64Int32(stackVal1Int64, stackVal2Int32_2);

            throw new System.NotImplementedException();
        }
    }
}