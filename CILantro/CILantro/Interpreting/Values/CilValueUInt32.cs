using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Values
{
    public struct CilValueUInt32 : IValue
    {
        public uint Value { get; }

        public CilValueUInt32(uint value)
        {
            Value = value;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory)
        {
            throw new System.NotImplementedException();
        }
    }
}