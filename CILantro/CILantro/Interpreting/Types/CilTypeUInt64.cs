using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackObjects;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeUInt64 : CilType
    {
        public override IStackObject CreateInstanceFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var value = new CilValueUInt64((ulong)obj);
            return value;
        }

        public override Type GetRuntimeType()
        {
            return typeof(ulong);
        }
    }
}