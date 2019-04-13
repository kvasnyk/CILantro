using System;

namespace CILantro.Structure
{
    public class CilTypeString : CilType
    {
        public override Type GetRuntimeType()
        {
            return typeof(string);
        }
    }
}