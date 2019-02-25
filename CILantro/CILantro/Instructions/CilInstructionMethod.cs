using CILantro.Structure;

namespace CILantro.Instructions
{
    public abstract class CilInstructionMethod : CilInstruction
    {
        public CilType ReturnType { get; set; }

        public CilTypeSpec TypeSpec { get; set; }

        public string MethodName { get; set; }
    }
}