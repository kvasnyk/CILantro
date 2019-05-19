using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeFloat64 : CilType
    {
        public override bool IsValueType => true;

        public override bool IsNullable => false;

        public override Type GetRuntimeType()
        {
            return typeof(double);
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueFloat64);
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var value = new CilValueFloat64((double)obj);
            return value;
        }

        public override IValue CreateDefaultValue(CilProgram program)
        {
            return new CilValueFloat64(default(double));
        }

        public override bool IsAssignableFrom(CilType other)
        {
            if (other is CilTypeFloat64)
                return true;

            return false;
        }
    }
}