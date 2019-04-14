using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackObjects;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Values
{
    public struct CilValueInt32 : IStackObject
    {
        public int Value { get; }

        public CilValueInt32(int value)
        {
            Value = value;
        }

        public T? As<T>()
            where T : struct, IStackObject
        {
            if (typeof(T) == typeof(CilValueInt32))
                return this as T?;

            if (typeof(T) == typeof(CilValueInt16))
                return new CilValueInt16((short)Value) as T?;

            throw new System.NotImplementedException();
        }

        public object AsRuntime(CilType type, CilManagedMemory managedMemory)
        {
            if (type is CilTypeInt32)
                return Value;

            throw new System.NotImplementedException();
        }
    }
}