using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Values
{
    public class CilValueInt32 : IValue
    {
        public int Value;

        public CilValueInt32(int value)
        {
            Value = value;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory)
        {
            if (cilType is CilTypeInt32)
                return Value;
            if (cilType is CilTypeUInt32)
                return (uint)Value;
            if (cilType is CilTypeChar)
                return (char)Value;

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