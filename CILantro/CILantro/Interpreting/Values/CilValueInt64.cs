using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;
using CILantro.Structure;

namespace CILantro.Interpreting.Values
{
    public class CilValueInt64 : IValue
    {
        public long Value { get; }

        public CilValueInt64(long value)
        {
            Value = value;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory, CilProgram program)
        {
            if (cilType is CilTypeInt64)
                return Value;
            if (cilType is CilTypeUInt64)
                return (ulong)Value;
            if (cilType is CilTypeValueType)
                return Value;

            throw new System.NotImplementedException();
        }

        public CilValueType Box()
        {
            throw new System.NotImplementedException();
        }

        public ref object GetRef()
        {
            throw new System.NotImplementedException();
        }

        public int GetPointerValue()
        {
            throw new System.NotImplementedException();
        }

        public IValue As(CilType cilType)
        {
            if (cilType is CilTypeInt64)
                return this;
            else if (cilType is CilTypeUInt64)
                return new CilValueUInt64((ulong)Value);

            throw new System.NotImplementedException();
        }
    }
}