using System.Collections.Generic;

namespace CILantro.Structure
{
    public class CilAssemblyRef
    {
        public string Name { get; set; }

        public List<CilAssemblyVersion> Versions { get; set; }

        public List<byte[]> PublicKeyTokens { get; set; }
    }
}