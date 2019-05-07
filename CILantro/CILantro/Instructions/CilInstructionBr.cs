namespace CILantro.Instructions
{
    public abstract class CilInstructionBr : CilInstruction
    {
        public int Offset { get; set; }

        public string Label { get; set; }
    }
}