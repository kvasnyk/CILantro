using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Values
{
    public struct CilValueUInt16 : IValue
    {
        public ushort Value { get; }

        public CilValueUInt16(ushort value)
        {
            Value = value;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory)
        {
            throw new System.NotImplementedException();
        }
    }
}