using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeInt32 : CilType
    {
        public override Type GetRuntimeType()
        {
            return typeof(int);
        }
    }
}