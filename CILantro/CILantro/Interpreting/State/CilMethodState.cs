using CILantro.Instructions;

namespace CILantro.Interpreting.State
{
    public class CilMethodState
    {
        public CilInstruction Instruction { get; set; }

        public CilEvaluationStack EvaluationStack { get; set; }

        public CilMethodInfo MethodInfo { get; set; }

        public CilLocals Locals { get; set; }
    }
}