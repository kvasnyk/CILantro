using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeChar : CilType
    {
        public override Type GetRuntimeType()
        {
            return typeof(char);
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueChar);
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var value = new CilValueChar((char)obj);
            return value;
        }
    }
}