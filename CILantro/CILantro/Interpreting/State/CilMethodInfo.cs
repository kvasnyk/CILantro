using CILantro.Instructions;
using CILantro.Structure;

namespace CILantro.Interpreting.State
{
    public class CilMethodInfo
    {
        private readonly CilMethod _method;

        public CilMethodInfo(CilMethod method)
        {
            _method = method;
        }

        public CilInstruction GetNextInstruction(CilInstruction instruction)
        {
            var instructionIndex = _method.Instructions.IndexOf(instruction);
            var nextInstructionIndex = instructionIndex + 1;
            if (nextInstructionIndex >= _method.Instructions.Count)
                return null;
            return _method.Instructions[nextInstructionIndex];
        }
    }
}