using CILantro.Instructions.Br;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackValues;
using CILantro.Interpreting.State;
using CILantro.Visitors;
using System;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionBrInterpreterVisitor : InstructionBrVisitor
    {
        private readonly CilControlState _state;

        private readonly CilManagedMemory _managedMemory;

        public InstructionBrInterpreterVisitor(CilControlState state, CilManagedMemory managedMemory)
        {
            _state = state;
            _managedMemory = managedMemory;
        }

        protected override void VisitBranchShortInstruction(BranchShortInstruction instruction)
        {
            _state.Move(instruction.Offset, instruction.Label);
        }

        protected override void VisitBranchOnEqualShortInstruction(BranchOnEqualShortInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.Value == b.Value,
                (a, b) => a.Value == b.Value,
                (a, b) => a.Value == b.Value
            );

            if (branch)
                _state.Move(instruction.Offset, instruction.Label);
            else
                _state.MoveToNextInstruction();
        }

        protected override void VisitBranchOnFalseShortInstruction(BranchOnFalseShortInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal);
            var branch = ComputeUnaryBranchOperation(
                stackVal,
                a => a.Value == 0
            );

            if (branch)
                _state.Move(instruction.Offset, instruction.Label);
            else
                _state.MoveToNextInstruction();
        }

        protected override void VisitBranchOnLessThanOrEqualToShortInstruction(BranchOnLessThanOrEqualToShortInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.Value <= b.Value,
                (a, b) => a.Value <= b.Value,
                (a, b) => a.Value <= b.Value
            );

            if (branch)
                _state.Move(instruction.Offset, instruction.Label);
            else
                _state.MoveToNextInstruction();
        }

        protected override void VisitBranchOnLessThanOrEqualToUnsignedShortInstruction(BranchOnLessThanOrEqualToUnsignedShortInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.ValueUnsigned <= b.ValueUnsigned,
                (a, b) => a.ValueUnsigned <= b.ValueUnsigned,
                (a, b) => a.Value <= b.Value
            );

            if (branch)
                _state.Move(instruction.Offset, instruction.Label);
            else
                _state.MoveToNextInstruction();
        }

        protected override void VisitBranchOnNotEqualUnsignedShortInstruction(BranchOnNotEqualUnsignedShortInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.ValueUnsigned != b.ValueUnsigned,
                (a, b) => a.ValueUnsigned != b.ValueUnsigned,
                (a, b) => a.Value != b.Value
            );

            if (branch)
                _state.Move(instruction.Offset, instruction.Label);
            else
                _state.MoveToNextInstruction();
        }

        protected override void VisitBranchOnTrueShortInstruction(BranchOnTrueShortInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var stackVal);
            var branch = ComputeUnaryBranchOperation(
                stackVal,
                a => a.Value != 0
            );

            if (branch)
                _state.Move(instruction.Offset, instruction.Label);
            else
                _state.MoveToNextInstruction();
        }

        private bool ComputeUnaryBranchOperation(
            IStackValue stackVal,
            Func<CilStackValueInt32, bool> computeInt32
        )
        {
            // TODO: cover all cases

            if (stackVal is CilStackValueInt32 stackValInt32)
                return computeInt32(stackValInt32);

            throw new System.NotImplementedException();
        }

        private bool ComputeBinaryBranchOperation(
            IStackValue stackVal1,
            IStackValue stackVal2,
            Func<CilStackValueInt32, CilStackValueInt32, bool> computeInt32Int32,
            Func<CilStackValueInt64, CilStackValueInt64, bool> computeInt64Int64,
            Func<CilStackValueFloat, CilStackValueFloat, bool> computeFloatFloat
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
    }
}