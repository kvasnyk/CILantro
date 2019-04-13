using System;

namespace CILantro.Structure
{
    public class CilTypeVoid : CilType
    {
        public override Type GetRuntimeType()
        {
            return typeof(void);
        }
    }
}