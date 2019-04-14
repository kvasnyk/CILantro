using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeChar : CilType
    {
        public override Type GetRuntimeType()
        {
            return typeof(char);
        }
    }
}