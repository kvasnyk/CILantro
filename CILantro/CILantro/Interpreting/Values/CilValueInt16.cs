using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Values
{
    public struct CilValueInt16 : IValue
    {
        public short Value { get; }

        public CilValueInt16(short value)
        {
            Value = value;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory)
        {
            if (cilType is CilTypeChar)
                return (char)Value;

            throw new System.NotImplementedException();
        }
    }
}