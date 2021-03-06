﻿using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;
using CILantro.Structure;

namespace CILantro.Interpreting.Values
{
    public class CilValueFloat64 : IValue
    {
        public double Value { get; }

        public CilValueFloat64(double value)
        {
            Value = value;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory, CilProgram program)
        {
            if (cilType is CilTypeFloat64)
                return Value;

            throw new System.NotImplementedException();
        }

        public CilValueType Box()
        {
            return new CilFloat64(this);
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
            if (cilType is CilTypeFloat64)
                return this;

            throw new System.NotImplementedException();
        }
    }
}