﻿using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Values
{
    public struct CilValueUInt8 : IValue
    {
        public byte Value { get; }

        public CilValueUInt8(byte value)
        {
            Value = value;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory)
        {
            if (cilType is CilTypeUInt8)
                return Value;

            throw new System.NotImplementedException();
        }
    }
}