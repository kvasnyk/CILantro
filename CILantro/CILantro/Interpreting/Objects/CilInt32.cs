using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;
using CILantro.Interpreting.Values;
using CILantro.Structure;

namespace CILantro.Interpreting.Objects
{
    public class CilInt32 : CilValueType
    {
        private CilValueInt32 Value { get; }

        public CilInt32(CilValueInt32 value)
        {
            Value = value;
        }

        public override object AsRuntime(CilType type, CilManagedMemory managedMemory, CilProgram program)
        {
            return Value.Value;
        }
    }
}