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
                case CilSimpleTypeKind.Int32:
                    return typeof(int);
                case CilSimpleTypeKind.String:
                    return typeof(string);
                case CilSimpleTypeKind.UInt8:
                    return typeof(byte);
                case CilSimpleTypeKind.Float64:
                    return typeof(double);
                case CilSimpleTypeKind.Float32:
                    return typeof(float);
                case CilSimpleTypeKind.Int64:
                    return typeof(long);
                case CilSimpleTypeKind.UInt64:
                    return typeof(ulong);
                case CilSimpleTypeKind.UInt32:
                    return typeof(uint);
                default:
                    throw new NotImplementedException("Cannot recognize runtime type.");
            }
        }
    }
}