using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Values
{
    public struct CilValueUInt64 : IValue
    {
        public ulong Value { get; }

        public CilValueUInt64(ulong value)
        {
            Value = value;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory)
        {
            throw new System.NotImplementedException();
        }
    }
}