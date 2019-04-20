using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeUInt32 : CilType
    {
        public override Type GetRuntimeType()
        {
            return typeof(uint);
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueUInt32);
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var value = new CilValueUInt32((uint)obj);
            return value;
        }
    }
}