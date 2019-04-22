using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Values
{
    public struct CilValueInt64 : IValue
    {
        public long Value { get; }

        public CilValueInt64(long value)
        {
            Value = value;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory)
        {
            if (cilType is CilTypeInt64)
                return Value;

            throw new System.NotImplementedException();
        }

        public CilValueType Box()
        {
            throw new System.NotImplementedException();
        }
    }
}