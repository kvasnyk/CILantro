using System.Collections.Generic;

namespace CILantro.Structure
{
    public class CilDecls
    {
        public List<CilAssemblyRef> AssemblyRefs { get; set; }

        public List<CilAssembly> Assemblies { get; set; }

        public List<CilClass> Classes { get; set; }

        public List<CilMethod> Methods { get; set; }
    }
}