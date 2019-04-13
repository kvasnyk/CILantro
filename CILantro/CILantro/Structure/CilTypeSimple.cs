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
                default:
                    throw new NotImplementedException("Cannot recognize runtime type.");
            }
        }
    }
}