using System.Collections.Generic;

namespace CILantro.Instructions
{
    public abstract class CilInstruction
    {
        public List<string> Labels { get; set; }

        public virtual bool IsSupported => true;

        public abstract override string ToString();
    }
}