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

        protected override void VisitLoadConstI41Instruction(LoadConstI41Instruction instruction)
        {
            var intValue = new CilInt32Value(1);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadConstI42Instruction(LoadConstI42Instruction instruction)
        {
            var intValue = new CilInt32Value(2);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadConstI43Instruction(LoadConstI43Instruction instruction)
        {
            var intValue = new CilInt32Value(3);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadConstI44Instruction(LoadConstI44Instruction instruction)
        {
            var intValue = new CilInt32Value(4);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadConstI45Instruction(LoadConstI45Instruction instruction)
        {
            var intValue = new CilInt32Value(5);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadConstI46Instruction(LoadConstI46Instruction instruction)
        {
            var intValue = new CilInt32Value(6);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadConstI47Instruction(LoadConstI47Instruction instruction)
        {
            var intValue = new CilInt32Value(7);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadConstI48Instruction(LoadConstI48Instruction instruction)
        {
            var intValue = new CilInt32Value(8);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadConstI4M1Instruction(LoadConstI4M1Instruction instruction)
        {
            var intValue = new CilInt32Value(-1);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitReturnInstruction(ReturnInstruction instruction)
        {
            _state.CurrentMethodState.Instruction = null;
        }
    }
}