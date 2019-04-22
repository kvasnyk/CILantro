using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Values
{
    public struct CilValueExternal : IValue
    {
        public object Value { get; }

        public CilValueExternal(object value)
        {
            Value = value;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory)
        {
            if (cilType is CilTypeValueType)
                return Value;

            throw new System.NotImplementedException();
        }

        public CilValueType Box()
        {
            throw new System.NotImplementedException();
        }
    }
}