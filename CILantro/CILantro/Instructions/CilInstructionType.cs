using CILantro.Structure;

namespace CILantro.Instructions
{
    public abstract class CilInstructionType : CilInstruction
    {
        public CilTypeSpec TypeSpec { get; set; }
    }
}