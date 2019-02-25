using CILantro.Instructions;
using System.Collections.Generic;

namespace CILantro.Structure
{
    public class CilMethod
    {
        public string Name { get; set; }

        public bool IsEntryPoint { get; set; }

        public List<CilInstruction> Instructions { get; set; }

        public CilInstruction GetNextInstruction(CilInstruction currentInstruction)
        {
            var currentInstructionIndex = Instructions.IndexOf(currentInstruction);
            var nextInstructionIndex = currentInstructionIndex + 1;
            if (nextInstructionIndex >= Instructions.Count)
                return null;
            return Instructions[nextInstructionIndex];
        }

        public override string ToString()
        {
            return Name;
        }
    }
}