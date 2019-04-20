using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeInt16 : CilType
    {
        public override Type GetRuntimeType()
        {
            return typeof(short);
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueInt16);
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var value = new CilValueInt16((short)obj);
            return value;
        }
    }
}