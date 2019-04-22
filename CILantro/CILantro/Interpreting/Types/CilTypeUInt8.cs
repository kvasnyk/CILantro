using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeUInt8 : CilType
    {
        public override bool IsValueType => throw new NotImplementedException();

        public override bool IsNullable => throw new NotImplementedException();

        public override Type GetRuntimeType()
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
    }
}