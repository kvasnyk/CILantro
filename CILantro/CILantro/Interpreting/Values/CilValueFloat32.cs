using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackObjects;
using CILantro.Interpreting.Types;
using System;

namespace CILantro.Interpreting.Values
{
    public struct CilValueFloat32 : IStackObject
    {
        public float Value { get; }

        public CilValueFloat32(float value)
        {
            Value = value;
        }

        public T? As<T>() where T : struct, IStackObject
        {
            throw new NotImplementedException();
        }

        public object AsRuntime(CilType type, CilManagedMemory managedMemory)
        {
            if (type is CilTypeFloat32)
                return Value;

            throw new NotImplementedException();
        }

        public IStackObject Add(IStackObject value2)
        {
            if (value2 is CilValueFloat32 float32)
                return new CilValueFloat32(Value + float32.Value);

            throw new NotImplementedException();
        }

        public IStackObject Convert<T>()
            where T : struct, IStackObject
        {
            if (typeof(T) == typeof(CilValueFloat32))
                return new CilValueFloat32(Value);
            if (typeof(T) == typeof(CilValueFloat64))
                return new CilValueFloat64(Value);

            throw new NotImplementedException();
        }
    }
}