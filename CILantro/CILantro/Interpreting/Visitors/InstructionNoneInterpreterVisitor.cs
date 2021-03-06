﻿using CILantro.Instructions.None;
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
        private readonly CilExecutionState _executionState;

        private readonly CilProgram _program;

        private CilControlState ControlState => _executionState.ControlState;

        private CilManagedMemory ManagedMemory => _executionState.ManagedMemory;

        public InstructionNoneInterpreterVisitor(CilProgram program, CilExecutionState executionState)
        {
            _executionState = executionState;

            _program = program;
        }

        protected override void VisitAddInstruction(AddInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryNumericOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value + b.Value),
                (a, b) => new CilStackValueInt64(a.Value + b.Value),
                (a, b) => new CilStackValueFloat(a.Value + b.Value)
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitAndInstruction(AndInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeIntegerOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value & b.Value),
                (a, b) => new CilStackValueInt64(a.Value & b.Value)
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitCompareEqualInstruction(CompareEqualInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryComparisonOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.Value == b.Value,
                (a, b) => a.Value == b.Value,
                (a, b) => a.Value == b.Value
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitCompareGreaterThanInstruction(CompareGreaterThanInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryComparisonOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.Value > b.Value,
                (a, b) => a.Value > b.Value,
                (a, b) => a.Value > b.Value
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitCompareGreaterThanUnsignedInstruction(CompareGreaterThanUnsignedInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryComparisonOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.ValueUnsigned > b.ValueUnsigned,
                (a, b) => a.ValueUnsigned > b.ValueUnsigned,
                (a, b) => a.Value > b.Value
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitCompareLessThanInstruction(CompareLessThanInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryComparisonOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.Value < b.Value,
                (a, b) => a.Value < b.Value,
                (a, b) => a.Value < b.Value
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitCompareLessThanUnsignedInstruction(CompareLessThanUnsignedInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryComparisonOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.ValueUnsigned < b.ValueUnsigned,
                (a, b) => a.ValueUnsigned < b.ValueUnsigned,
                (a, b) => a.Value < b.Value
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitConvertI1Instruction(ConvertI1Instruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => new CilStackValueInt32((sbyte)x.Value),
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); }
            );
            ControlState.EvaluationStack.Push(newStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitConvertI2Instruction(ConvertI2Instruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => new CilStackValueInt32((short)x.Value),
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); }
            );
            ControlState.EvaluationStack.Push(newStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitConvertI4Instruction(ConvertI4Instruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => { throw new NotImplementedException(); },
                x => new CilStackValueInt32((int)x.Value),
                x => new CilStackValueInt32((int)x.Value),
                x => { throw new NotImplementedException(); },
                x => new CilStackValueInt32(x.Value)
            );
            ControlState.EvaluationStack.Push(newStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitConvertI8Instruction(ConvertI8Instruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => new CilStackValueInt64(x.Value),
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); }
            );
            ControlState.EvaluationStack.Push(newStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitConvertR4Instruction(ConvertR4Instruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => new CilStackValueFloat((float)x.Value),
                x => new CilStackValueFloat((float)x.Value),
                x => new CilStackValueFloat((float)x.Value),
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); }
            );
            ControlState.EvaluationStack.Push(newStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitConvertR8Instruction(ConvertR8Instruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => new CilStackValueFloat((double)x.Value),
                x => new CilStackValueFloat((double)x.Value),
                x => new CilStackValueFloat(x.Value),
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); }
            );
            ControlState.EvaluationStack.Push(newStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitConvertRUnsignedInstruction(ConvertRUnsignedInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => new CilStackValueFloat((double)x.ValueUnsigned),
                x => new CilStackValueFloat((double)x.ValueUnsigned),
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); }
            );
            ControlState.EvaluationStack.Push(newStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitConvertUInstruction(ConvertUInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => new CilStackValueNativeInt(x.ValueToRef.GetPointerValue()),
                x => { throw new NotImplementedException(); }
            );
            ControlState.EvaluationStack.Push(newStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitConvertU1Instruction(ConvertU1Instruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => new CilStackValueInt32((byte)x.ValueUnsigned),
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); }
            );
            ControlState.EvaluationStack.Push(newStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitConvertU2Instruction(ConvertU2Instruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => new CilStackValueInt32((ushort)x.ValueUnsigned),
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); }
            );
            ControlState.EvaluationStack.Push(newStackVal);

            ControlState.MoveToNextInstruction(); ;
        }

        protected override void VisitConvertU8Instruction(ConvertU8Instruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal);
            var newStackVal = ComputeConversionOperation(
                stackVal,
                x => new CilStackValueInt64((long)(ulong)x.ValueUnsigned),
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); },
                x => { throw new NotImplementedException(); }
            );
            ControlState.EvaluationStack.Push(newStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitDivideInstruction(DivideInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryNumericOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value / b.Value),
                (a, b) => new CilStackValueInt64(a.Value / b.Value),
                (a, b) => new CilStackValueFloat(a.Value / b.Value)
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitDivideUnsignedInstruction(DivideUnsignedInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeIntegerOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32((int)(a.ValueUnsigned / b.ValueUnsigned)),
                (a, b) => new CilStackValueInt64((long)(a.ValueUnsigned / b.ValueUnsigned))
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitDuplicateInstruction(DuplicateInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var value);

            ControlState.EvaluationStack.Push(value);
            ControlState.EvaluationStack.Push(value);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitIndirectLoadI4Instruction(IndirectLoadI4Instruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueManagedPointer valuePointer);

            ControlState.EvaluationStack.PushValue(valuePointer.ValueToRef);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitIndirectStoreI4Instruction(IndirectStoreI4Instruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueManagedPointer pointer, out CilValueInt32 value);

            var int32PointerValue = pointer.ValueToRef as CilValueInt32;
            int32PointerValue.Value = value.Value;

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadArgument0Instruction(LoadArgument0Instruction instruction)
        {
            var value = ControlState.Arguments.Load(null, 0);
            ControlState.EvaluationStack.PushValue(value);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadArgument1Instruction(LoadArgument1Instruction instruction)
        {
            var value = ControlState.Arguments.Load(null, 1);
            ControlState.EvaluationStack.PushValue(value);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadArgument2Instruction(LoadArgument2Instruction instruction)
        {
            var value = ControlState.Arguments.Load(null, 2);
            ControlState.EvaluationStack.PushValue(value);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadArgument3Instruction(LoadArgument3Instruction instruction)
        {
            var value = ControlState.Arguments.Load(null, 3);
            ControlState.EvaluationStack.PushValue(value);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementI1Instruction(LoadArrayElementI1Instruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, new CilTypeInt8(), ManagedMemory, _program);

            ControlState.EvaluationStack.PushValue(elem);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementI2Instruction(LoadArrayElementI2Instruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, new CilTypeInt16(), ManagedMemory, _program);

            ControlState.EvaluationStack.PushValue(elem);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementI4Instruction(LoadArrayElementI4Instruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, new CilTypeInt32(), ManagedMemory, _program);

            ControlState.EvaluationStack.PushValue(elem);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementI8Instruction(LoadArrayElementI8Instruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, new CilTypeInt64(), ManagedMemory, _program);

            ControlState.EvaluationStack.PushValue(elem);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementR4Instruction(LoadArrayElementR4Instruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, new CilTypeFloat32(), ManagedMemory, _program);

            ControlState.EvaluationStack.PushValue(elem);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementR8Instruction(LoadArrayElementR8Instruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, new CilTypeFloat64(), ManagedMemory, _program);

            ControlState.EvaluationStack.PushValue(elem);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementRefInstruction(LoadArrayElementRefInstruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, null, ManagedMemory, _program);

            ControlState.EvaluationStack.PushValue(elem);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementU1Instruction(LoadArrayElementU1Instruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, new CilTypeUInt8(), ManagedMemory, _program);

            ControlState.EvaluationStack.PushValue(elem);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementU2Instruction(LoadArrayElementU2Instruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, new CilTypeUInt16(), ManagedMemory, _program);

            ControlState.EvaluationStack.PushValue(elem);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementU4Instruction(LoadArrayElementU4Instruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, new CilTypeUInt32(), ManagedMemory, _program);

            ControlState.EvaluationStack.PushValue(elem);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI40Intruction(LoadConstI40Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(0);
            ControlState.EvaluationStack.Push(stackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI41Instruction(LoadConstI41Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(1);
            ControlState.EvaluationStack.Push(stackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI42Instruction(LoadConstI42Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(2);
            ControlState.EvaluationStack.Push(stackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI43Instruction(LoadConstI43Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(3);
            ControlState.EvaluationStack.Push(stackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI44Instruction(LoadConstI44Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(4);
            ControlState.EvaluationStack.Push(stackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI45Instruction(LoadConstI45Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(5);
            ControlState.EvaluationStack.Push(stackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI46Instruction(LoadConstI46Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(6);
            ControlState.EvaluationStack.Push(stackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI47Instruction(LoadConstI47Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(7);
            ControlState.EvaluationStack.Push(stackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI48Instruction(LoadConstI48Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(8);
            ControlState.EvaluationStack.Push(stackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI4M1Instruction(LoadConstI4M1Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(-1);
            ControlState.EvaluationStack.Push(stackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadLengthInstruction(LoadLengthInstruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef);
            var array = ManagedMemory.Load(arrayRef) as CilArray;

            ControlState.EvaluationStack.Push(new CilStackValueNativeInt(array.Length));

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadLocal0Instruction(LoadLocal0Instruction instruction)
        {
            var value = ControlState.Locals.Load(null, 0);
            ControlState.EvaluationStack.PushValue(value);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadLocal1Instruction(LoadLocal1Instruction instruction)
        {
            var value = ControlState.Locals.Load(null, 1);
            ControlState.EvaluationStack.PushValue(value);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadLocal2Instruction(LoadLocal2Instruction instruction)
        {
            var value = ControlState.Locals.Load(null, 2);
            ControlState.EvaluationStack.PushValue(value);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadLocal3Instruction(LoadLocal3Instruction instruction)
        {
            var value = ControlState.Locals.Load(null, 3);
            ControlState.EvaluationStack.PushValue(value);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitMultiplyInstruction(MultiplyInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryNumericOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value * b.Value),
                (a, b) => new CilStackValueInt64(a.Value * b.Value),
                (a, b) => new CilStackValueFloat(a.Value * b.Value)
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitNegateInstruction(NegateInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal);
            var resultStackVal = ComputeUnaryNumericOperation(
                stackVal,
                a => new CilStackValueInt32(-a.Value),
                a => new CilStackValueInt64(-a.Value),
                a => new CilStackValueFloat(-a.Value)
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitNotInstruction(NotInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal);
            var resultStackVal = ComputeUnaryIntegerOperation(
                stackVal,
                a => new CilStackValueInt32(~a.Value),
                a => new CilStackValueInt64(~a.Value)
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitOrInstruction(OrInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeIntegerOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value | b.Value),
                (a, b) => new CilStackValueInt64(a.Value | b.Value)
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitPopInstruction(PopInstruction instruction)
        {
            var stackValue = ControlState.EvaluationStack.Pop();

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitRemainderInstruction(RemainderInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryNumericOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value % b.Value),
                (a, b) => new CilStackValueInt64(a.Value % b.Value),
                (a, b) => new CilStackValueFloat(a.Value % b.Value)
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitRemainderUnsignedInstruction(RemainderUnsignedInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeIntegerOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32((int)(a.ValueUnsigned % b.ValueUnsigned)),
                (a, b) => new CilStackValueInt64((long)(a.ValueUnsigned % b.ValueUnsigned))
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitReturnInstruction(ReturnInstruction instruction)
        {
            var currentMethodState = ControlState.CallStack.Pop();

            if (currentMethodState.EvaluationStack.IsEmpty)
            {
            }
            else
            {
                if (ControlState.CallStack.Count == 0)
                {
                    currentMethodState.EvaluationStack.PopValue(out CilValueInt32 value);
                    ControlState.ProgramResult = value.Value;
                }
                else
                {
                    currentMethodState.EvaluationStack.PopValue(_program, currentMethodState.MethodInfo.ReturnType, out var value);
                    ControlState.EvaluationStack.PushValue(value);
                }

                if (!currentMethodState.EvaluationStack.IsEmpty)
                    throw new Exception("The evaluation stack is not empty!");
            }
        }

        protected override void VisitShiftLeftInstruction(ShiftLeftInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeShiftOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value << b.Value),
                (a, b) => new CilStackValueInt64(a.Value << b.Value)
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitShiftRightInstruction(ShiftRightInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeShiftOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value >> b.Value),
                (a, b) => new CilStackValueInt64(a.Value >> b.Value)
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitShiftRightUnsignedInstruction(ShiftRightUnsignedInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeShiftOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32((int)(a.ValueUnsigned >> b.Value)),
                (a, b) => new CilStackValueInt64((long)(a.ValueUnsigned >> b.Value))
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitStoreArrayElementI1Instruction(StoreArrayElementI1Instruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal, out CilValueInt8 valueVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            array.SetValue(valueVal, indexVal, ManagedMemory);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitStoreArrayElementI2Instruction(StoreArrayElementI2Instruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal, out CilValueInt16 valueVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            array.SetValue(valueVal, indexVal, ManagedMemory);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitStoreArrayElementI4Instruction(StoreArrayElementI4Instruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal, out CilValueInt32 valueVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            array.SetValue(valueVal, indexVal, ManagedMemory);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitStoreArrayElementI8Instruction(StoreArrayElementI8Instruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal, out CilValueInt64 valueVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            array.SetValue(valueVal, indexVal, ManagedMemory);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitStoreArrayElementR4Instruction(StoreArrayElementR4Instruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal, out CilValueFloat32 valueVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            array.SetValue(valueVal, indexVal, ManagedMemory);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitStoreArrayElementR8Instruction(StoreArrayElementR8Instruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal, out CilValueFloat64 valueVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            array.SetValue(valueVal, indexVal, ManagedMemory);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitStoreArrayElementRefInstruction(StoreArrayElementRefInstruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal, out CilValueReference valueVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            array.SetValue(valueVal, indexVal, ManagedMemory);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitStoreLocal0Instruction(StoreLocal0Instruction instruction)
        {
            var localType = ControlState.Locals.GetLocalType(null, 0);
            ControlState.EvaluationStack.PopValue(_program, localType, out var value);
            ControlState.Locals.Store(null, 0, value);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitStoreLocal1Instruction(StoreLocal1Instruction instruction)
        {
            var localType = ControlState.Locals.GetLocalType(null, 1);
            ControlState.EvaluationStack.PopValue(_program, localType, out var value);
            ControlState.Locals.Store(null, 1, value);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitStoreLocal2Instruction(StoreLocal2Instruction instruction)
        {
            var localType = ControlState.Locals.GetLocalType(null, 2);
            ControlState.EvaluationStack.PopValue(_program, localType, out var value);
            ControlState.Locals.Store(null, 2, value);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitStoreLocal3Instruction(StoreLocal3Instruction instruction)
        {
            var localType = ControlState.Locals.GetLocalType(null, 3);
            ControlState.EvaluationStack.PopValue(_program, localType, out var value);
            ControlState.Locals.Store(null, 3, value);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitSubtractInstruction(SubtractInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeBinaryNumericOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value - b.Value),
                (a, b) => new CilStackValueInt64(a.Value - b.Value),
                (a, b) => new CilStackValueFloat(a.Value - b.Value)
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitXorInstruction(XorInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var resultStackVal = ComputeIntegerOperation(
                stackVal1,
                stackVal2,
                (a, b) => new CilStackValueInt32(a.Value ^ b.Value),
                (a, b) => new CilStackValueInt64(a.Value ^ b.Value)
            );
            ControlState.EvaluationStack.Push(resultStackVal);

            ControlState.MoveToNextInstruction();
        }

        private IStackValue ComputeUnaryNumericOperation(
            IStackValue stackVal,
            Func<CilStackValueInt32, CilStackValueInt32> computeInt32,
            Func<CilStackValueInt64, CilStackValueInt64> computeInt64,
            Func<CilStackValueFloat, CilStackValueFloat> computeFloat
        )
        {
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
            Func<CilStackValuePointer, IStackValue> computePointer,
            Func<CilStackValueNativeInt, IStackValue> computeNativeInt
        )
        {
            if (stackVal is CilStackValueInt32 stackValInt32)
                return computeInt32(stackValInt32);
            if (stackVal is CilStackValueInt64 stackValInt64)
                return computeInt64(stackValInt64);
            if (stackVal is CilStackValueFloat stackValFloat)
                return computeFloat(stackValFloat);
            if (stackVal is CilStackValuePointer stackValPointer)
                return computePointer(stackValPointer);
            if (stackVal is CilStackValueNativeInt stackValNativeInt)
                return computeNativeInt(stackValNativeInt);

            throw new System.NotImplementedException();
        }

        private IStackValue ComputeUnaryIntegerOperation(
            IStackValue stackVal,
            Func<CilStackValueInt32, CilStackValueInt32> computeInt32,
            Func<CilStackValueInt64, CilStackValueInt64> computeInt64
        )
        {
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
            if (stackVal1 is CilStackValueInt32 stackVal1Int32 && stackVal2 is CilStackValueInt32 stackVal2Int32)
                return computeInt32Int32(stackVal1Int32, stackVal2Int32);
            if (stackVal1 is CilStackValueInt64 stackVal1Int64 && stackVal2 is CilStackValueInt32 stackVal2Int32_2)
                return computeInt64Int32(stackVal1Int64, stackVal2Int32_2);

            throw new System.NotImplementedException();
        }
    }
}