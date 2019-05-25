using System.Collections.Generic;

namespace CILantro.Structure
{
    public class CilClassDecls
    {
        public List<CilMethod> Methods { get; set; }

        public List<CilField> Fields { get; set; }

        public List<CilClass> Classes { get; set; }
    }
}