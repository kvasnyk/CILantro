using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeVoid : CilType
    {
        public override bool IsValueType(CilProgram program)
        {
            throw new NotImplementedException();
        }

        public override bool IsNullable => throw new NotImplementedException();

        public override Type GetRuntimeType(CilProgram program)
        {
            throw new NotImplementedException();
        }

        public override Type GetValueType(CilProgram program)
        {
            throw new NotImplementedException();
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            throw new ArgumentException("Cannot create an instance of type void.");
        }

        public override IValue CreateDefaultValue(CilProgram program)
        {
            throw new NotImplementedException();
        }

        public override bool IsAssignableFrom(CilType other)
        {
            if (other is CilTypeVoid)
                return true;

            return false;
        }

        public override IValue Unbox(CilObject obj, CilManagedMemory managedMemory, CilProgram program)
        {
            throw new NotImplementedException();
        }
    }
}