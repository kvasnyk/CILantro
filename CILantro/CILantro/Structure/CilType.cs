using System;

namespace CILantro.Structure
{
    public class CilType
    {
        // TODO: consider another name
        public CilTypeType TypeType { get; set; }

        public Type GetRuntimeType()
        {
            switch (TypeType)
            {
                case CilTypeType.Bool:
                    return typeof(bool);
                case CilTypeType.Int32:
                    return typeof(Int32);
                case CilTypeType.String:
                    return typeof(string);
                case CilTypeType.Void:
                    return typeof(void);
                default:
                    throw new NotImplementedException("Cannot recognize runtime type.");
            }
        }
    }
}