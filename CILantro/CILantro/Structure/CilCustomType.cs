using System.Collections.Generic;

namespace CILantro.Structure
{
    public class CilCustomType
    {
        public CilCallConv CallConv { get; set; }

        public CilType Type { get; set; }

        public CilTypeSpec TypeSpec { get; set; }

        public List<CilSigArg> SigArgs { get; set; }
    }
}