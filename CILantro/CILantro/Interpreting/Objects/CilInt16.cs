using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;
using CILantro.Interpreting.Values;
using CILantro.Structure;

namespace CILantro.Interpreting.Objects
{
    public class CilInt16 : CilValueType
    {
        public CilValueInt16 Value { get; }

        public CilInt16(CilValueInt16 value)
        {
            Value = value;
        }

        public override object AsRuntime(CilType type, CilManagedMemory managedMemory, CilProgram program)
        {
            return Value.Value;
        }
    }
}