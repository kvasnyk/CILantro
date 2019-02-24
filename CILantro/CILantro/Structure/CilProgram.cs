using System.Collections.Generic;
using System.Linq;

namespace CILantro.Structure
{
    public class CilProgram
    {
        public List<CilAssemblyRef> AssemblyRefs { get; }

        public List<CilClass> Classes { get; }

        public CilMethod EntryPoint => Classes.Single(c => c.EntryPoint != null).EntryPoint;

        public CilProgram(CilDecls decls)
        {
            AssemblyRefs = decls.AssemblyRefs;
            Classes = decls.Classes;
        }
    }
}