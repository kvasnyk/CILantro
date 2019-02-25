using CILantro.Interpreting;

namespace CILantro.Instructions.None
{
    public class RetInstruction : CilInstructionNone
    {
        public override void Execute(CilControlState state)
        {
            state.CurrentMethodState.Instruction = null;
        }

        public override string ToString()
        {
            return "ret";
        }
    }
}