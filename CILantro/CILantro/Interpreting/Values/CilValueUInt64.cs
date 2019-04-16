using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackObjects;
using CILantro.Interpreting.Types;
using System;

namespace CILantro.Interpreting.Values
{
    public struct CilValueUInt64 : IStackObject
    {
        public ulong Value { get; }

        public CilValueUInt64(ulong value)
        {
            Value = value;
        }

        public T? As<T>() where T : struct, IStackObject
        {
            throw new NotImplementedException();
        }

        public object AsRuntime(CilType type, CilManagedMemory managedMemory)
        {
            if (type is CilTypeUInt64)
                return Value;
            if (type is CilTypeInt64)
                return (long)Value;

            throw new NotImplementedException();
        }

        public IStackObject Add(IStackObject value2)
        {
            //if (value2 is CilValueInt8 int8)
            //    throw new ArgumentException();
            //if (value2 is CilValueInt16 int16)
            //    throw new ArgumentException();
            //if (value2 is CilValueInt32 int32)
            //    throw new ArgumentException();
            if (value2 is CilValueInt64 int64)
                return new CilValueUInt64(Value + (ulong)int64.Value);

            //if (value2 is CilValueUInt8 uint8)
            //    return new CilValueUInt64(Value + uint8.Value);
            //if (value2 is CilValueUInt16 uint16)
            //    return new CilValueUInt64(Value + uint16.Value);
            //if (value2 is CilValueUInt32 uint32)
            //    return new CilValueUInt64(Value + uint32.Value);
            if (value2 is CilValueUInt64 uint64)
                return new CilValueUInt64(Value + uint64.Value);

            //if (value2 is CilValueChar @char)
            //    return new CilValueUInt64(Value + @char.Value);

            throw new NotImplementedException();
        }

        public IStackObject Convert(CilType type)
        {
            if (type is CilTypeFloat32)
                return new CilValueFloat32(Value);
            if (type is CilTypeFloat64)
                return new CilValueFloat64(Value);
            if (type is CilTypeUInt32)
                return new CilValueUInt32((uint)Value);
            if (type is CilTypeUInt64)
                return new CilValueUInt64(Value);

            throw new NotImplementedException();
        }

        public IStackObject Sub(IStackObject value2)
        {
            //if (value2 is CilValueInt8 int8)
            //    throw new ArgumentException();
            //if (value2 is CilValueInt16 int16)
            //    throw new ArgumentException();
            //if (value2 is CilValueInt32 int32)
            //    throw new ArgumentException();
            if (value2 is CilValueInt64 int64)
                return new CilValueUInt64(Value - (ulong)int64.Value);

            //if (value2 is CilValueUInt8 uint8)
            //    return new CilValueUInt64(Value + uint8.Value);
            //if (value2 is CilValueUInt16 uint16)
            //    return new CilValueUInt64(Value + uint16.Value);
            //if (value2 is CilValueUInt32 uint32)
            //    return new CilValueUInt64(Value + uint32.Value);
            if (value2 is CilValueUInt64 uint64)
                return new CilValueUInt64(Value - uint64.Value);

            //if (value2 is CilValueChar @char)
            //    return new CilValueUInt64(Value + @char.Value);

            throw new NotImplementedException();
        }
    }
}