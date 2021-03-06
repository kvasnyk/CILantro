﻿using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;
using CILantro.Structure;

namespace CILantro.Interpreting.Values
{
    public class CilValueInt8 : IValue
    {
        public sbyte Value { get; }

        public CilValueInt8(sbyte value)
        {
            Value = value;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory, CilProgram program)
        {
            if (cilType is CilTypeInt8)
                return Value;
            if (cilType is CilTypeUInt8)
                return (byte)Value;
            if (cilType is CilTypeValueType)
                return Value;

            throw new System.NotImplementedException();
        }

        public CilValueType Box()
        {
            throw new System.NotImplementedException();
        }

        public ref object GetRef()
        {
            throw new System.NotImplementedException();
        }

        public int GetPointerValue()
        {
            throw new System.NotImplementedException();
        }

        public IValue As(CilType cilType)
        {
            if (cilType is CilTypeInt8)
                return this;
            if (cilType is CilTypeUInt8)
                return new CilValueUInt8((byte)Value);

            throw new System.NotImplementedException();
        }
    }
}