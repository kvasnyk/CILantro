using CILantro.Interpreting.Types;
using CILantro.Structure;

namespace CILantro.Instructions
{
    public abstract class CilInstructionField : CilInstruction
    {
        public CilType FieldType { get; set; }

        public CilTypeSpec ClassTypeSpec { get; set; }

        public string FieldId { get; set; }
    }
}