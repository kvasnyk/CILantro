using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackObjects;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Values
{
    public struct CilValueInt32 : IStackObject
    {
        public int Value { get; }

        public CilValueInt32(int value)
        {
            Value = value;
        }

        public T? As<T>()
            where T : struct, IStackObject
        {
            if (typeof(T) == typeof(CilValueInt32))
                return this as T?;

            if (typeof(T) == typeof(CilValueInt16))
                return new CilValueInt16((short)Value) as T?;

            throw new System.NotImplementedException();
        }

        public object AsRuntime(CilType type, CilManagedMemory managedMemory)
        {
            if (type is CilTypeInt32)
                return Value;

            throw new System.NotImplementedException();
        }

        public IStackObject Add(IStackObject value2)
        {
            if (value2 is CilValueInt8 int8)
                return new CilValueInt32(Value + int8.Value);
            if (value2 is CilValueInt16 int16)
                return new CilValueInt32(Value + int16.Value);
            if (value2 is CilValueInt32 int32)
                return new CilValueInt32(Value + int32.Value);
            //if (value2 is CilValueInt64 int64)
            //    return new CilValueInt64(Value + int64.Value);

            if (value2 is CilValueUInt8 uint8)
                return new CilValueInt32(Value + uint8.Value);
            if (value2 is CilValueUInt16 uint16)
                return new CilValueInt32(Value + uint16.Value);
            //if (value2 is CilValueUInt32 uint32)
            //    return new CilValueInt64(Value + uint32.Value);
            //if (value2 is CilValueUInt64 uint64)
            //    throw new ArgumentException();

            if (value2 is CilValueChar @char)
                return new CilValueInt32(Value + @char.Value);

            throw new System.NotImplementedException();
        }

        public IStackObject Convert<T>()
            where T : struct, IStackObject
        {
            if (typeof(T) == typeof(CilValueInt64))
                return new CilValueInt64(Value);
            if (typeof(T) == typeof(CilValueFloat32))
                return new CilValueFloat32(Value);
            if (typeof(T) == typeof(CilValueFloat64))
                return new CilValueFloat64(Value);
            if (typeof(T) == typeof(CilValueInt8))
                return new CilValueInt8((sbyte)Value);
            if (typeof(T) == typeof(CilValueInt16))
                return new CilValueInt16((short)Value);
            if (typeof(T) == typeof(CilValueUInt16))
                return new CilValueUInt16((ushort)Value);
            if (typeof(T) == typeof(CilValueUInt8))
                return new CilValueUInt8((byte)Value);

            throw new System.NotImplementedException();
        }

        public IStackObject Sub(IStackObject value2)
        {
            if (value2 is CilValueInt8 int8)
                return new CilValueInt32(Value - int8.Value);
            if (value2 is CilValueInt16 int16)
                return new CilValueInt32(Value - int16.Value);
            if (value2 is CilValueInt32 int32)
                return new CilValueInt32(Value - int32.Value);
            //if (value2 is CilValueInt64 int64)
            //    return new CilValueInt64(Value + int64.Value);

            if (value2 is CilValueUInt8 uint8)
                return new CilValueInt32(Value - uint8.Value);
            if (value2 is CilValueUInt16 uint16)
                return new CilValueInt32(Value - uint16.Value);
            //if (value2 is CilValueUInt32 uint32)
            //    return new CilValueInt64(Value + uint32.Value);
            //if (value2 is CilValueUInt64 uint64)
            //    throw new ArgumentException();

            if (value2 is CilValueChar @char)
                return new CilValueInt32(Value - @char.Value);

            throw new System.NotImplementedException();
        }
    }
}