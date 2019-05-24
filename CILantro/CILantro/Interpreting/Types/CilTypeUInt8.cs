using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeUInt8 : CilType
    {
        public override bool IsValueType(CilProgram program)
        {
            throw new NotImplementedException();
        }

        public override bool IsNullable => throw new NotImplementedException();

        public override Type GetRuntimeType(CilProgram program)
        {
            return typeof(byte);
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueUInt8);
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var value = new CilValueUInt8((byte)obj);
            return value;
        }

        public override IValue CreateDefaultValue(CilProgram program)
        {
            return new CilValueUInt8(default(byte));
        }

        public override bool IsAssignableFrom(CilType other)
        {
            if (other is CilTypeUInt8)
                return true;

            return false;
        }

        public override IValue Unbox(CilObject obj, CilManagedMemory managedMemory, CilProgram program)
        {
            throw new NotImplementedException();
        }
    }
}