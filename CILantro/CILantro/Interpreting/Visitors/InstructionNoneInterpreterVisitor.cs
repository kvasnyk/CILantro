using CILantro.Instructions.None;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
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

        protected override void VisitLoadConstI40Intruction(LoadConstI40Instruction instruction)
        {
            var intValue = new CilInt32Value(0);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitReturnInstruction(ReturnInstruction instruction)
        {
            _state.CurrentMethodState.Instruction = null;
        }
    }
}