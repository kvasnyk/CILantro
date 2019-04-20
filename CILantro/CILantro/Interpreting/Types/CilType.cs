using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public abstract class CilType
    {
        public abstract Type GetRuntimeType();

        public abstract Type GetValueType(CilProgram program);

        public abstract IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program);
    }
}