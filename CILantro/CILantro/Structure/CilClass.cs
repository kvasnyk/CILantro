using System.Collections.Generic;

namespace CILantro.Structure
{
    public class CilClass
    {
        public string Name { get; set; }

        public List<CilMethod> Methods { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}