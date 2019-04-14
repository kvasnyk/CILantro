using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackObjects;
using CILantro.Interpreting.Types;
using System;

namespace CILantro.Interpreting.Values
{
    public struct CilValueUInt8 : IStackObject
    {
        public byte Value { get; }

        public CilValueUInt8(byte value)
        {
            Value = value;
        }

        public T? As<T>() where T : struct, IStackObject
        {
            throw new System.NotImplementedException();
        }

        public object AsRuntime(CilType type, CilManagedMemory managedMemory)
        {
            if (type is CilTypeUInt8)
                return Value;
            if (type is CilTypeInt32)
                return (int)Value;

            throw new NotImplementedException();
        }
    }
}