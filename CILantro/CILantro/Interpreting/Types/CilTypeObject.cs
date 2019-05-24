using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeObject : CilType
    {
        public override bool IsValueType(CilProgram program)
        {
            throw new NotImplementedException();
        }

        public override bool IsNullable => throw new NotImplementedException();

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var cilObj = new CilObjectExternal(obj);
            var objRef = managedMemory.Store(cilObj);
            return objRef;
        }

        public override Type GetRuntimeType(CilProgram program)
        {
            return typeof(object);
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueReference);
        }

        public override IValue CreateDefaultValue(CilProgram program)
        {
            throw new NotImplementedException();
        }

        public override bool IsAssignableFrom(CilType other)
        {
            throw new NotImplementedException();
        }
    }
}