using System.Collections.Generic;
using System.Linq;

namespace CILantro.Structure
{
    public class CilClass
    {
        public CilClassName Name { get; set; }

        public CilClassName ExtendsName { get; set; }

        public CilClass Extends { get; set; }

        public List<CilMethod> Methods { get; set; }

        public List<CilField> Fields { get; set; }

        public CilMethod EntryPoint => Methods.SingleOrDefault(m => m.IsEntryPoint);

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}