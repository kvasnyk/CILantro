﻿using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Values
{
    public class CilValueManagedPointer : IValue
    {
        public IValue ValueToRef { get; set; }

        public CilValueManagedPointer(IValue valueToRef)
        {
            ValueToRef = valueToRef;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory, CilProgram program)
        {
            throw new NotImplementedException();
        }

        public CilValueType Box()
        {
            throw new NotImplementedException();
        }

        public ref object GetRef()
        {
            throw new NotImplementedException();
        }

        public int GetPointerValue()
        {
            throw new NotImplementedException();
        }

        public IValue As(CilType cilType)
        {
            throw new NotImplementedException();
        }
    }
}