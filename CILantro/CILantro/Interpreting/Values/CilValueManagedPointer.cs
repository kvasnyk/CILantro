using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;
using System;

namespace CILantro.Interpreting.Values
{
    public class CilValueManagedPointer : IValue
    {
        public IValue ValueToRef { get; private set; }

        public CilValueManagedPointer(IValue valueToRef)
        {
            ValueToRef = valueToRef;
        }

        public void SetValue(IValue valueToRef)
        {
            ValueToRef = valueToRef;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory)
        {
            throw new NotImplementedException();
        }

        public CilValueType Box()
        {
            throw new NotImplementedException();
        }

        public ref object GetRef()
        {
            throw new NotImplementedException();
        }

        public int GetPointerValue()
        {
            throw new NotImplementedException();
        }
    }
}