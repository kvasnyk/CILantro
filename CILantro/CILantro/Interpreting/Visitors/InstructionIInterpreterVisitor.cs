using CILantro.Instructions.I;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.State;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionIInterpreterVisitor : InstructionIVisitor
    {
        private readonly CilControlState _state;

        private readonly CilHeap _heap;

        public InstructionIInterpreterVisitor(CilControlState state, CilHeap heap)
        {
            _state = state;
            _heap = heap;
        }

        protected override void VisitLoadConstI4ShortInstruction(LoadConstI4ShortInstruction instruction)
        {
            var intValue = new CilInt32Value(instruction.Value);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }
    }
}