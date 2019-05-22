using CILantro.Structure;
using System.Collections.Generic;

namespace CILantro.Instructions
{
    public abstract class CilInstructionSwitch : CilInstruction
    {
        public List<CilLabel> Labels { get; set; }
    }
}