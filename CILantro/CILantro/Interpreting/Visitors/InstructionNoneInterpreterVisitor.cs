using CILantro.Instructions.None;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.State;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionNoneInterpreterVisitor : InstructionNoneVisitor
    {
        private readonly CilControlState _state;

        private readonly CilHeap _heap;

        public InstructionNoneInterpreterVisitor(CilControlState state, CilHeap heap)
        {
            _state = state;
            _heap = heap;
        }

        protected override void VisitReturnInstruction(ReturnInstruction instruction)
        {
            _state.CurrentMethodState.Instruction = null;
        }
    }
}