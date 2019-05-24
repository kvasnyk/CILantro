using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeInt16 : CilType
    {
        public override bool IsValueType(CilProgram program)
        {
            return true;
        }

        public override bool IsNullable => false;

        public override Type GetRuntimeType(CilProgram program)
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

        public override IValue CreateDefaultValue(CilProgram program)
        {
            return new CilValueInt16(default(short));
        }

        public override bool IsAssignableFrom(CilType other)
        {
            if (other is CilTypeInt16)
                return true;

            return false;
        }
    }
}