using CILantro.Interpreting.Objects;
using System;

namespace CILantro.Structure
{
    public class CilTypeSimple : CilType
    {
        public CilSimpleTypeKind Kind { get; set; }

        public override Type GetRuntimeType()
        {
            switch (Kind)
            {
                case CilSimpleTypeKind.Bool:
                    return typeof(bool);
                case CilSimpleTypeKind.Char:
                    return typeof(char);
                case CilSimpleTypeKind.Float32:
                    return typeof(float);
                case CilSimpleTypeKind.Float64:
                    return typeof(double);
                case CilSimpleTypeKind.Int16:
                    return typeof(short);
                case CilSimpleTypeKind.Int32:
                    return typeof(int);
                case CilSimpleTypeKind.Int64:
                    return typeof(long);
                case CilSimpleTypeKind.Int8:
                    return typeof(sbyte);
                case CilSimpleTypeKind.UInt16:
                    return typeof(ushort);
                case CilSimpleTypeKind.UInt32:
                    return typeof(uint);
                case CilSimpleTypeKind.UInt64:
                    return typeof(ulong);
                case CilSimpleTypeKind.UInt8:
                    return typeof(byte);
                default:
                    throw new NotImplementedException("Cannot recognize runtime type.");
            }
        }

        public CilValue BuildValue(object obj)
        {
            switch (Kind)
            {
                case CilSimpleTypeKind.Bool:
                    return new CilBoolValue((bool)obj);
                case CilSimpleTypeKind.Char:
                    return new CilCharValue((char)obj);
                case CilSimpleTypeKind.Float32:
                    return new CilFloat32Value((float)obj);
                case CilSimpleTypeKind.Float64:
                    return new CilFloat64Value((double)obj);
                case CilSimpleTypeKind.Int16:
                    return new CilInt16Value((short)obj);
                case CilSimpleTypeKind.Int32:
                    return new CilInt32Value((int)obj);
                case CilSimpleTypeKind.Int64:
                    return new CilInt64Value((long)obj);
                case CilSimpleTypeKind.Int8:
                    return new CilInt8Value((sbyte)obj);
                case CilSimpleTypeKind.UInt16:
                    return new CilUInt16Value((ushort)obj);
                case CilSimpleTypeKind.UInt32:
                    return new CilUInt32Value((uint)obj);
                case CilSimpleTypeKind.UInt64:
                    return new CilUInt64Value((ulong)obj);
                case CilSimpleTypeKind.UInt8:
                    return new CilUInt8Value((byte)obj);
                default:
                    throw new NotImplementedException($"Cannot build ${nameof(CilValue)}.");

            }
        }
    }
}