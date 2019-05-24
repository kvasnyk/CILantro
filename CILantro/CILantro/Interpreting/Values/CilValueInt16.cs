using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;
using CILantro.Structure;

namespace CILantro.Interpreting.Values
{
    public class CilValueInt16 : IValue
    {
        public short Value { get; }

        public CilValueInt16(short value)
        {
            Value = value;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory, CilProgram program)
        {
            if (cilType is CilTypeChar)
                return (char)Value;
            if (cilType is CilTypeInt16)
                return Value;
            if (cilType is CilTypeUInt16)
                return (ushort)Value;
            if (cilType is CilTypeValueType)
                return Value;

            throw new System.NotImplementedException();
        }

        public CilValueType Box()
        {
            return new CilInt16(this);
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
            if (cilType is CilTypeInt16)
                return this;
            else if (cilType is CilTypeUInt16)
                return new CilValueUInt16((ushort)Value);

            throw new System.NotImplementedException();
        }
    }
}