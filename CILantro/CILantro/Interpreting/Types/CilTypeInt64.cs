using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeInt64 : CilType
    {
        public override bool IsValueType => throw new NotImplementedException();

        public override bool IsNullable => throw new NotImplementedException();

        public override Type GetRuntimeType()
        {
            return typeof(long);
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueInt64);
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var value = new CilValueInt64(Convert.ToInt64(obj));
            return value;
        }

        public override IValue CreateDefaultValue(CilProgram program)
        {
            return new CilValueInt64(default(long));
        }

        public override bool IsAssignableFrom(CilType other)
        {
            if (other is CilTypeInt64)
                return true;

            return false;
        }
    }
}