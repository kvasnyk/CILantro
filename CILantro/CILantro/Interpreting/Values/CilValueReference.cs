﻿using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;
using CILantro.Structure;

namespace CILantro.Interpreting.Values
{
    public class CilValueReference : IValue
    {
        public int? Address { get; }

        public CilValueReference(int? address)
        {
            Address = address;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory, CilProgram program)
        {
            var result = managedMemory.Load(this);
            return result.AsRuntime(cilType, managedMemory, program);
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
            if (cilType is CilTypeString)
                return this;
            if (cilType is CilTypeClass)
                return this;
            if (cilType is CilTypeArray)
                return this;

            throw new System.NotImplementedException();
        }
    }
}