using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackObjects;
using CILantro.Interpreting.Types;
using System;

namespace CILantro.Interpreting.Values
{
    public struct CilValueFloat64 : IStackObject
    {
        public double Value { get; }

        public CilValueFloat64(double value)
        {
            Value = value;
        }

        public T? As<T>() where T : struct, IStackObject
        {
            throw new NotImplementedException();
        }

        public object AsRuntime(CilType type, CilManagedMemory managedMemory)
        {
            if (type is CilTypeFloat64)
                return Value;

            throw new NotImplementedException();
        }

        public IStackObject Add(IStackObject value2)
        {
            if (value2 is CilValueFloat64 float64)
                return new CilValueFloat64(Value + float64.Value);

            throw new NotImplementedException();
        }

        public IStackObject Convert<T>() where T : struct, IStackObject
        {
            if (typeof(T) == typeof(CilValueFloat32))
                return new CilValueFloat32((float)Value);
            if (typeof(T) == typeof(CilValueFloat64))
                return new CilValueFloat64(Value);

            throw new NotImplementedException();
        }
    }
}