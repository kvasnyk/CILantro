using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;
using System;

namespace CILantro.Interpreting.Values
{
    public struct CilValueManagedPointer : IValue
    {
        public int Address { get; set; }

        public CilValueManagedPointer(int address)
        {
            Address = address;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory)
        {
            throw new NotImplementedException();
        }

        public CilValueType Box()
        {
            throw new NotImplementedException();
        }
    }
}