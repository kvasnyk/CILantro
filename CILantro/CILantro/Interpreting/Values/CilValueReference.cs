using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Values
{
    public struct CilValueReference : IValue
    {
        public int Address { get; }

        public CilValueReference(int address)
        {
            Address = address;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory)
        {
            var result = managedMemory.Load(this);
            return result.AsRuntime(cilType);
        }
    }
}