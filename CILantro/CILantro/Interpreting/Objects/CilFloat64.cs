using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;
using CILantro.Interpreting.Values;

namespace CILantro.Interpreting.Objects
{
    public class CilFloat64 : CilValueType
    {
        private CilValueFloat64 Value { get; }

        public CilFloat64(CilValueFloat64 value)
        {
            Value = value;
        }

        public override object AsRuntime(CilType type, CilManagedMemory managedMemory)
        {
            return Value.Value;
        }
    }
}