using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeManagedPointer : CilType
    {
        public CilType InnerType { get; }

        public override bool IsValueType => throw new NotImplementedException();

        public override bool IsNullable => throw new NotImplementedException();

        public CilTypeManagedPointer(CilType innerType)
        {
            InnerType = innerType;
        }

        public override IValue CreateDefaultValue(CilProgram program)
        {
            throw new NotImplementedException();
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            throw new NotImplementedException();
        }

        public override Type GetRuntimeType(CilProgram program)
        {
            throw new NotImplementedException();
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueManagedPointer);
        }

        public override bool IsAssignableFrom(CilType other)
        {
            if (other is CilTypeManagedPointer otherManagedPointer)
            {
                if (InnerType.IsAssignableFrom(otherManagedPointer.InnerType))
                    return true;
            }

            return false;
        }
    }
}