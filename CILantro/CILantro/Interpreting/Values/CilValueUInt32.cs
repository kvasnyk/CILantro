using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackObjects;
using CILantro.Interpreting.Types;
using System;

namespace CILantro.Interpreting.Values
{
    public struct CilValueUInt32 : IStackObject
    {
        public uint Value { get; }

        public CilValueUInt32(uint value)
        {
            Value = value;
        }

        public T? As<T>() where T : struct, IStackObject
        {
            throw new NotImplementedException();
        }

        public object AsRuntime(CilType type, CilManagedMemory managedMemory)
        {
            if (type is CilTypeUInt32)
                return Value;

            throw new NotImplementedException();
        }
    }
}