using CILantro.Instructions.String;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionStringInterpreterVisitor : InstructionStringVisitor
    {
        private readonly CilControlState _state;

        public InstructionStringInterpreterVisitor(CilControlState state)
        {
            _state = state;
        }

        protected override void VisitLoadStringInstruction(LoadStringInstruction instruction)
        {
            _state.CurrentEvaluationStack.Push(instruction.StringValue);
            _state.CurrentMethodState.Instruction = _state.CurrentMethod.GetNextInstruction(instruction);
        }
    }
}