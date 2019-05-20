using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Values
{
    public class CilValueChar : IValue
    {
        public char Value { get; }

        public CilValueChar(char value)
        {
            Value = value;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory)
        {
            if (cilType is CilTypeChar)
                return Value;
            if (cilType is CilTypeInt32)
                return (int)Value;

            throw new System.NotImplementedException();
        }

        public CilValueType Box()
        {
            return new CilChar(this);
        }

        public ref object GetRef()
        {
            throw new System.NotImplementedException();
        }

        public int GetPointerValue()
        {
            throw new System.NotImplementedException();
        }
    }
}