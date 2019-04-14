using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackObjects;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public abstract class CilType
    {
        public abstract Type GetRuntimeType();

        public abstract IStackObject CreateInstanceFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program);
    }
}