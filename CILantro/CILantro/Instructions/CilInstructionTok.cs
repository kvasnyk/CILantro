using CILantro.Interpreting.Types;
using CILantro.Structure;

namespace CILantro.Instructions
{
    public abstract class CilInstructionTok : CilInstruction
    {
        public CilTypeSpec TypeSpec { get; set; }

        public CilType FieldType { get; set; }

        public CilTypeSpec FieldTypeSpec { get; set; }

        public string FieldId { get; set; }
    }
}