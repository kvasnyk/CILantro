using CILantro.Instructions.String;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.State;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionStringInterpreterVisitor : InstructionStringVisitor
    {
        private readonly CilControlState _state;

        private readonly CilHeap _heap;

        public InstructionStringInterpreterVisitor(CilControlState state, CilHeap heap)
        {
            _state = state;
            _heap = heap;
        }

        protected override void VisitLoadStringInstruction(LoadStringInstruction instruction)
        {
            var stringAddress = _heap.Store(instruction.StringValue);
            var stringRef = new CilReference(stringAddress);

            _state.CurrentEvaluationStack.Push(stringRef);
            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }
    }
}