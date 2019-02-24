using System.Collections.Generic;

namespace CILantro.Model
{
    public class CilCustomType
    {
        public CilCallConv CallConv { get; }

        public CilType Type { get; }

        public CilTypeSpec TypeSpec { get; }

        public List<CilSigArg> SigArgs { get; }

        public CilCustomType(CilCallConv callConv, CilType type, CilTypeSpec typeSpec, List<CilSigArg> sigArgs)
        {
            CallConv = callConv;
            Type = type;
            TypeSpec = typeSpec;
            SigArgs = sigArgs;
        }
    }
}