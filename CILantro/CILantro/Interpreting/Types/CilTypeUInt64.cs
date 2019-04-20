using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeUInt64 : CilType
    {
        public override Type GetRuntimeType()
        {
            return typeof(ulong);
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueUInt64);
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var value = new CilValueUInt64((ulong)obj);
            return value;
        }
    }
}