namespace CILantro.Instructions.Var
{
    public class LoadLocalShortInstruction : CilInstructionVar
    {
        public override string ToString()
        {
            return "ldloc.s";
        }
    }
}