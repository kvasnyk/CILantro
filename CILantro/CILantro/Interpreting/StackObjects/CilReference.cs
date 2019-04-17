﻿using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.StackObjects
{
    public struct CilReference : IStackObject
    {
        public int Address { get; }

        public CilReference(int address)
        {
            Address = address;
        }

        public T? As<T>()
            where T : struct, IStackObject
        {
            if (typeof(T) == typeof(CilReference))
                return this as T?;

            throw new System.NotImplementedException();
        }

        public object AsRuntime(CilType type, CilManagedMemory managedMemory)
        {
            var result = managedMemory.Load(this);
            return result.AsRuntime(type);
        }

        public IStackObject Add(IStackObject value2)
        {
            throw new System.NotImplementedException();
        }

        public IStackObject Sub(IStackObject value2)
        {
            throw new System.NotImplementedException();
        }

        public IStackObject Convert(CilType type)
        {
            return this; // TODO: is this really correct?

            throw new System.NotImplementedException();
        }

        public IStackObject Mul(IStackObject value2)
        {
            throw new System.NotImplementedException();
        }

        public IStackObject Div(IStackObject value2)
        {
            throw new System.NotImplementedException();
        }

        public IStackObject Mod(IStackObject value2)
        {
            throw new System.NotImplementedException();
        }
    }
}