using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeInt32 : CilType
    {
        public override bool IsValueType => true;

        public override bool IsNullable => false;

        public override Type GetRuntimeType(CilProgram program)
        {
            return typeof(int);
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueInt32);
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var value = new CilValueInt32((int)obj);
            return value;
        }

        public override IValue CreateDefaultValue(CilProgram program)
        {
            return new CilValueInt32(default(int));
        }

        public override bool IsAssignableFrom(CilType other)
        {
            if (other is CilTypeInt32)
                return true;

            return false;
        }
    }
}