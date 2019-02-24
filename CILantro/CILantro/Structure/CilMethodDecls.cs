using CILantro.Instructions;
using System.Collections.Generic;

namespace CILantro.Structure
{
    public class CilMethodDecls
    {
        public List<bool> EntryPoints { get; set; }

        public List<CilInstruction> Instructions { get; set; }
    }
}