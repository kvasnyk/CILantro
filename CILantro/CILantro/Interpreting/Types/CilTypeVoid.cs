using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeVoid : CilType
    {
        public override Type GetRuntimeType()
        {
            throw new NotImplementedException();
        }
    }
}