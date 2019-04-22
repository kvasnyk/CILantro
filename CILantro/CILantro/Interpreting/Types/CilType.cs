﻿using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public abstract class CilType
    {
        public abstract bool IsValueType { get; }

        public abstract bool IsNullable { get; }

        public abstract Type GetRuntimeType();

        public abstract Type GetValueType(CilProgram program);

        public abstract IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program);
    }
}