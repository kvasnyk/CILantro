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
    }
}