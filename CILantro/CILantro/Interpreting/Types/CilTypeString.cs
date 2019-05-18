using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeString : CilType
    {
        public override bool IsValueType => throw new NotImplementedException();

        public override bool IsNullable => throw new NotImplementedException();

        public override Type GetRuntimeType()
        {
            return typeof(string);
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueReference);
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var cilString = new CilString(obj as string);
            var stringRef = managedMemory.Store(cilString);
            return stringRef;
        }

        public override IValue CreateDefaultValue(CilProgram program)
        {
            return new CilValueNull();
        }

        public override bool IsAssignableFrom(CilType other)
        {
            if (other is CilTypeString)
                return true;

            return false;
        }
    }
}