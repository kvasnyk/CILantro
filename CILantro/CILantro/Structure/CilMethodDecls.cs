using CILantro.Instructions;
using System.Collections.Generic;

namespace CILantro.Structure
{
    public class CilMethodDecls
    {
        public bool IsEntryPoint { get; set; }

        public List<CilInstruction> Instructions { get; set; }

        public List<CilSigArg> Locals { get; set; }
    }
}