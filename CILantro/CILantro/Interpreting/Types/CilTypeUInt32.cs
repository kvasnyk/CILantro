using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeUInt32 : CilType
    {
        public override bool IsValueType(CilProgram program)
        {
            throw new NotImplementedException();
        }

        public override bool IsNullable => throw new NotImplementedException();

        public override Type GetRuntimeType(CilProgram program)
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

        public override IValue CreateDefaultValue(CilProgram program)
        {
            return new CilValueUInt32(default(uint));
        }

        public override bool IsAssignableFrom(CilType other)
        {
            if (other is CilTypeUInt32)
                return true;

            return false;
        }
    }
}