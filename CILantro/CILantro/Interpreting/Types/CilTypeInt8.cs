using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeInt8 : CilType
    {
        public override Type GetRuntimeType()
        {
            return typeof(sbyte);
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueInt8);
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var value = new CilValueInt8((sbyte)obj);
            return value;
        }
    }
}