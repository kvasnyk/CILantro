﻿using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;
using CILantro.Structure;

namespace CILantro.Interpreting.Values
{
    public class CilValueFloat32 : IValue
    {
        public float Value { get; }

        public CilValueFloat32(float value)
        {
            Value = value;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory, CilProgram program)
        {
            if (cilType is CilTypeFloat32)
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
            if (cilType is CilTypeFloat32)
                return this;

            throw new System.NotImplementedException();
        }
    }
}