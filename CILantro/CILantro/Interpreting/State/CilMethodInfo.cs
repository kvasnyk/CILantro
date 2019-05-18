using CILantro.Instructions;
using CILantro.Structure;
using System.Linq;

namespace CILantro.Interpreting.State
{
    public class CilMethodInfo
    {
        private readonly CilMethod _method;

        public bool IsConstructor => _method.IsConstructor;

        public CilMethodInfo(CilMethod method)
        {
            _method = method;
        }

        public CilInstruction GetFirstInstruction()
        {
            return _method.Instructions.First();
        }

        public CilInstruction GetNextInstruction(CilInstruction instruction)
        {
            var instructionIndex = _method.Instructions.IndexOf(instruction);
            var nextInstructionIndex = instructionIndex + 1;
            if (nextInstructionIndex >= _method.Instructions.Count)
                return null;
            return _method.Instructions[nextInstructionIndex];
        }

        public CilInstruction GetInstructionByLabel(string label)
        {
            return _method.Instructions.Single(i => i.Labels.Contains(label));
        }

        public CilInstruction GetInstructionByOffset(CilInstruction instruction, int offset)
        {
            throw new System.NotImplementedException();
        }
    }
}