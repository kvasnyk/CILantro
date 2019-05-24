using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeInt8 : CilType
    {
        public override bool IsValueType(CilProgram program)
        {
            throw new NotImplementedException();
        }

        public override bool IsNullable => throw new NotImplementedException();

        public override Type GetRuntimeType(CilProgram program)
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

        public override IValue CreateDefaultValue(CilProgram program)
        {
            return new CilValueInt8(default(sbyte));
        }

        public override bool IsAssignableFrom(CilType other)
        {
            if (other is CilTypeInt8)
                return true;

            return false;
        }

        public override IValue Unbox(CilObject obj, CilManagedMemory managedMemory, CilProgram program)
        {
            throw new NotImplementedException();
        }
    }
}