using CILantro.Instructions;
using CILantro.Structure;
using System.Linq;

namespace CILantro.Interpreting.State
{
    public class CilMethodState
    {
        public CilInstruction Instruction { get; set; }

        public CilEvaluationStack EvaluationStack { get; set; }

        public CilMethodInfo MethodInfo { get; set; }

        public CilLocals Locals { get; set; }

        public CilMethodState(CilMethod method)
        {
            Instruction = method.Instructions.First();
            EvaluationStack = new CilEvaluationStack();
            MethodInfo = new CilMethodInfo(method);
            Locals = new CilLocals(method.Locals);
        }
    }
}