using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeBool : CilType
    {
        public override bool IsValueType => throw new NotImplementedException();

        public override bool IsNullable => throw new NotImplementedException();

        public override Type GetRuntimeType()
        {
            return typeof(bool);
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueBool);
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var value = new CilValueBool((bool)obj);
            return value;
        }
    }
}