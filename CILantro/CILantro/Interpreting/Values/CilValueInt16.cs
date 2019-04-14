using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackObjects;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Values
{
    public struct CilValueInt16 : IStackObject
    {
        public short Value { get; }

        public CilValueInt16(short value)
        {
            Value = value;
        }

        public T? As<T>()
            where T : struct, IStackObject
        {
            throw new System.NotImplementedException();
        }

        public object AsRuntime(CilType type, CilManagedMemory managedMemory)
        {
            if (type is CilTypeChar)
                return (char)Value;

            throw new System.NotImplementedException();
        }
    }
}