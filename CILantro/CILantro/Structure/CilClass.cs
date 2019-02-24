using System.Collections.Generic;
using System.Linq;

namespace CILantro.Structure
{
    public class CilClass
    {
        public string Name { get; set; }

        public List<CilMethod> Methods { get; set; }

        public CilMethod EntryPoint => Methods.SingleOrDefault(m => m.IsEntryPoint);

        public override string ToString()
        {
            return Name;
        }
    }
}