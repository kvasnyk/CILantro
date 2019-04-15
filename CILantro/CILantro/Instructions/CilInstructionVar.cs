namespace CILantro.Instructions
{
    public abstract class CilInstructionVar : CilInstruction
    {
        public string Id { get; set; }

        public int Index { get; set; }
    }
}