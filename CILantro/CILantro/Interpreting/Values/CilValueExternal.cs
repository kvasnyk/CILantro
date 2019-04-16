using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackObjects;
using CILantro.Interpreting.Types;
using System;

namespace CILantro.Interpreting.Values
{
    public struct CilValueExternal : IStackObject
    {
        public object Value { get; }

        public CilValueExternal(object value)
        {
            Value = value;
        }

        public T? As<T>() where T : struct, IStackObject
        {
            throw new NotImplementedException();
        }

        public object AsRuntime(CilType type, CilManagedMemory managedMemory)
        {
            if (type is CilTypeValueType)
                return Value;

            throw new NotImplementedException();
        }

        public IStackObject Add(IStackObject value2)
        {
            throw new NotImplementedException();
        }

        public IStackObject Sub(IStackObject value2)
        {
            throw new NotImplementedException();
        }

        public IStackObject Convert(CilType type)
        {
            return this; // TODO: is this really correct?

            throw new NotImplementedException();
        }
    }
}