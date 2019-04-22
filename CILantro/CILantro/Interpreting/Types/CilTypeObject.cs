using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeObject : CilType
    {
        public override bool IsValueType => throw new NotImplementedException();

        public override bool IsNullable => throw new NotImplementedException();

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            throw new NotImplementedException();
        }

        public override Type GetRuntimeType()
        {
            return typeof(object);
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueReference);
        }
    }
}