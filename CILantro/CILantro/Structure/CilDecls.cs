using System.Collections.Generic;

namespace CILantro.Structure
{
    public class CilDecls
    {
        public List<CilAssemblyRef> AssemblyRefs { get; set; }

        public List<CilClass> Classes { get; set; }
    }
}