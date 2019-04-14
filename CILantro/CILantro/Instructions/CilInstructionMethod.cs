using CILantro.Interpreting.Types;
using CILantro.Structure;
using System.Collections.Generic;

namespace CILantro.Instructions
{
    public abstract class CilInstructionMethod : CilInstruction
    {
        public CilType ReturnType { get; set; }

        public CilTypeSpec TypeSpec { get; set; }

        public string MethodName { get; set; }

        public List<CilSigArg> SigArgs { get; set; }

        public CilCallConv CallConv { get; set; }

        public CilCallKind CallKind { get; set; }
    }
}