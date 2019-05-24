using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;
using CILantro.Structure;

namespace CILantro.Interpreting.Values
{
    public class CilValueInt32 : IValue
    {
        public int Value;

        public CilValueInt32(int value)
        {
            Value = value;
        }

        public IValue As(CilType cilType)
        {
            if (cilType is CilTypeInt32)
                return this;
            else if (cilType is CilTypeUInt32)
                return new CilValueUInt32((uint)Value);

            throw new System.NotImplementedException();
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory, CilProgram program)
        {
            if (cilType is CilTypeInt32)
                return Value;
            if (cilType is CilTypeUInt32)
                return (uint)Value;
            if (cilType is CilTypeChar)
                return (char)Value;
            if (cilType is CilTypeValueType)
                return Value;

            throw new System.NotImplementedException();
        }

        public CilValueType Box()
        {
            return new CilInt32(this);
        }

        public unsafe int GetPointerValue()
        {
            fixed (int* pointer = &Value)
            {
                return (int)pointer;
            }
        }

        public ref object GetRef()
        {
            throw new System.NotImplementedException();
        }
    }
}