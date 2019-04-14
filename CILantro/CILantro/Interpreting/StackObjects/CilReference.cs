using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.StackObjects
{
    public struct CilReference : IStackObject
    {
        public int Address { get; }

        public CilReference(int address)
        {
            Address = address;
        }

        public T? As<T>()
            where T : struct, IStackObject
        {
            if (typeof(T) == typeof(CilReference))
                return this as T?;

            throw new System.NotImplementedException();
        }

        public object AsRuntime(CilType type, CilManagedMemory managedMemory)
        {
            var result = managedMemory.Load(this);
            return result.AsRuntime(type);
        }
    }
}