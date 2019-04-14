using CILantro.Instructions.String;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.State;
using CILantro.Visitors;
using System;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionStringInterpreterVisitor : InstructionStringVisitor
    {
        private readonly CilControlState _state;

        private readonly CilManagedMemory _managedMemory;

        public InstructionStringInterpreterVisitor(CilControlState state, CilManagedMemory managedMemory)
        {
            _state = state;
            _managedMemory = managedMemory;
        }

        protected override void VisitLoadStringInstruction(LoadStringInstruction instruction)
        {
            // TODO: correct implementation

            //var stringAddress = _heap.Store(instruction.StringValue);
            //var stringRef = new CilReference(stringAddress);

            //_state.CurrentEvaluationStack.Push(stringRef);
            //_state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);

            throw new NotImplementedException();
        }
    }
}