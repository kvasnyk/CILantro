using System.Collections.Generic;

namespace CILantro.Structure
{
    public class CilAssemblyRefDecls
    {
        public List<byte[]> PublicKeyTokens { get; set; }

        public List<CilAssemblyVersion> Versions { get; set; }
    }
}