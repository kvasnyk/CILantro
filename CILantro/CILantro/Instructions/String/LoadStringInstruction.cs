using CILantro.Interpreting;

namespace CILantro.Instructions.String
{
    public class LoadStringInstruction : CilInstructionString
    {
        public override void Execute(CilControlState state)
        {
            state.CurrentEvaluationStack.Push(StringValue);
            state.CurrentMethodState.Instruction = state.CurrentMethod.GetNextInstruction(this);
        }

        public override string ToString()
        {
            return "ldstr";
        }
    }
}