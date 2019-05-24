using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public abstract class CilType
    {
        public abstract bool IsValueType(CilProgram program);

        public abstract bool IsNullable { get; }

        public abstract Type GetRuntimeType(CilProgram program);

        public abstract Type GetValueType(CilProgram program);

        public abstract IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program);

        public abstract IValue CreateDefaultValue(CilProgram program);

        public abstract bool IsAssignableFrom(CilType other);
    }
}