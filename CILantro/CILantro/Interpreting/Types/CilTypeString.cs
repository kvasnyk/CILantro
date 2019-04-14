using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeString : CilType
    {
        public override Type GetRuntimeType()
        {
            return typeof(string);
        }
    }
}