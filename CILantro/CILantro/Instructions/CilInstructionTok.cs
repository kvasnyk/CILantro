using CILantro.Structure;

namespace CILantro.Instructions
{
    public abstract class CilInstructionTok : CilInstruction
    {
        public CilTypeSpec TypeSpec { get; set; }
    }
}