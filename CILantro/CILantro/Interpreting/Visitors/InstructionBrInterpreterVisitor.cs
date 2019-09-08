using CILantro.Instructions.Br;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackValues;
using CILantro.Interpreting.State;
using CILantro.Structure;
using CILantro.Visitors;
using System;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionBrInterpreterVisitor : InstructionBrVisitor
    {
        private readonly CilExecutionState _executionState;

        private readonly CilProgram _program;

        private CilControlState ControlState => _executionState.ControlState;

        private CilManagedMemory ManagedMemory => _executionState.ManagedMemory;

        public InstructionBrInterpreterVisitor(CilProgram program, CilExecutionState executionState)
        {
            _executionState = executionState;

            _program = program;
        }

        protected override void VisitBranchInstruction(BranchInstruction instruction)
        {
            ControlState.Move(instruction.Offset, instruction.Label);
        }

        protected override void VisitBranchShortInstruction(BranchShortInstruction instruction)
        {
            ControlState.Move(instruction.Offset, instruction.Label);
        }

        protected override void VisitBranchOnEqualShortInstruction(BranchOnEqualShortInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.Value == b.Value,
                (a, b) => a.Value == b.Value,
                (a, b) => a.Value == b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnEqualInstruction(BranchOnEqualInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.Value == b.Value,
                (a, b) => a.Value == b.Value,
                (a, b) => a.Value == b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnFalseShortInstruction(BranchOnFalseShortInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal);
            var branch = ComputeUnaryBranchOperation(
                stackVal,
                a => a.Value == 0,
                a => a.Value == 0
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnFalseInstruction(BranchOnFalseInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal);
            var branch = ComputeUnaryBranchOperation(
                stackVal,
                a => a.Value == 0,
                a => a.Value == 0
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnGreaterThanShortInstruction(BranchOnGreaterThanShortInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.Value > b.Value,
                (a, b) => a.Value > b.Value,
                (a, b) => a.Value > b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnGreaterThanInstruction(BranchOnGreaterThanInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.Value > b.Value,
                (a, b) => a.Value > b.Value,
                (a, b) => a.Value > b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnGreaterThanUnsignedShortInstruction(BranchOnGreaterThanUnsignedShortInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.ValueUnsigned > b.ValueUnsigned,
                (a, b) => a.ValueUnsigned > b.ValueUnsigned,
                (a, b) => a.Value > b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnGreaterThanUnsignedInstruction(BranchOnGreaterThanUnsignedInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.ValueUnsigned > b.ValueUnsigned,
                (a, b) => a.ValueUnsigned > b.ValueUnsigned,
                (a, b) => a.Value > b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnGreaterThanOrEqualToShortInstruction(BranchOnGreaterThanOrEqualToShortInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.Value >= b.Value,
                (a, b) => a.Value >= b.Value,
                (a, b) => a.Value >= b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnGreaterThanOrEqualToInstruction(BranchOnGreaterThanOrEqualToInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.Value >= b.Value,
                (a, b) => a.Value >= b.Value,
                (a, b) => a.Value >= b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnGreaterThanOrEqualToUnsignedShortInstruction(BranchOnGreaterThanOrEqualToUnsignedShortInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.ValueUnsigned >= b.ValueUnsigned,
                (a, b) => a.ValueUnsigned >= b.ValueUnsigned,
                (a, b) => a.Value >= b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnGreaterThanOrEqualToUnsignedInstruction(BranchOnGreaterThanOrEqualToUnsignedInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.ValueUnsigned >= b.ValueUnsigned,
                (a, b) => a.ValueUnsigned >= b.ValueUnsigned,
                (a, b) => a.Value >= b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnLessThanShortInstruction(BranchOnLessThanShortInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.Value < b.Value,
                (a, b) => a.Value < b.Value,
                (a, b) => a.Value < b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnLessThanInstruction(BranchOnLessThanInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.Value < b.Value,
                (a, b) => a.Value < b.Value,
                (a, b) => a.Value < b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnLessThanUnsignedShortInstruction(BranchOnLessThanUnsignedShortInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.ValueUnsigned < b.ValueUnsigned,
                (a, b) => a.ValueUnsigned < b.ValueUnsigned,
                (a, b) => a.Value < b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnLessThanUnsignedInstruction(BranchOnLessThanUnsignedInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.ValueUnsigned < b.ValueUnsigned,
                (a, b) => a.ValueUnsigned < b.ValueUnsigned,
                (a, b) => a.Value < b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnLessThanOrEqualToShortInstruction(BranchOnLessThanOrEqualToShortInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.Value <= b.Value,
                (a, b) => a.Value <= b.Value,
                (a, b) => a.Value <= b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnLessThanOrEqualToInstruction(BranchOnLessThanOrEqualToInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.Value <= b.Value,
                (a, b) => a.Value <= b.Value,
                (a, b) => a.Value <= b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnLessThanOrEqualToUnsignedShortInstruction(BranchOnLessThanOrEqualToUnsignedShortInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.ValueUnsigned <= b.ValueUnsigned,
                (a, b) => a.ValueUnsigned <= b.ValueUnsigned,
                (a, b) => a.Value <= b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnLessThanOrEqualToUnsignedInstruction(BranchOnLessThanOrEqualToUnsignedInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.ValueUnsigned <= b.ValueUnsigned,
                (a, b) => a.ValueUnsigned <= b.ValueUnsigned,
                (a, b) => a.Value <= b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnNotEqualUnsignedShortInstruction(BranchOnNotEqualUnsignedShortInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.ValueUnsigned != b.ValueUnsigned,
                (a, b) => a.ValueUnsigned != b.ValueUnsigned,
                (a, b) => a.Value != b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnNotEqualUnsignedInstruction(BranchOnNotEqualUnsignedInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal1, out var stackVal2);
            var branch = ComputeBinaryBranchOperation(
                stackVal1,
                stackVal2,
                (a, b) => a.ValueUnsigned != b.ValueUnsigned,
                (a, b) => a.ValueUnsigned != b.ValueUnsigned,
                (a, b) => a.Value != b.Value
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnTrueShortInstruction(BranchOnTrueShortInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal);
            var branch = ComputeUnaryBranchOperation(
                stackVal,
                a => a.Value != 0,
                a => a.Value != 0
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        protected override void VisitBranchOnTrueInstruction(BranchOnTrueInstruction instruction)
        {
            ControlState.EvaluationStack.Pop(out var stackVal);
            var branch = ComputeUnaryBranchOperation(
                stackVal,
                a => a.Value != 0,
                a => a.Value != 0
            );

            if (branch)
                ControlState.Move(instruction.Offset, instruction.Label);
            else
                ControlState.MoveToNextInstruction();
        }

        private bool ComputeUnaryBranchOperation(
            IStackValue stackVal,
            Func<CilStackValueInt32, bool> computeInt32,
            Func<CilStackValueInt64, bool> computeInt64
        )
        {
            if (stackVal is CilStackValueInt32 stackValInt32)
                return computeInt32(stackValInt32);
            if (stackVal is CilStackValueInt64 stackValInt64)
                return computeInt64(stackValInt64);

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