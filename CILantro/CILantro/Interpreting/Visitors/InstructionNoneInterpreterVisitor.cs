using CILantro.Instructions.None;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionNoneInterpreterVisitor : InstructionNoneVisitor
    {
        private readonly CilControlState _state;

        public InstructionNoneInterpreterVisitor(CilControlState state)
        {
            _state = state;
        }

        protected override void VisitReturnInstruction(ReturnInstruction instruction)
        {
            _state.CurrentMethodState.Instruction = null;
        }
    }
}