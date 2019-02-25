using CILantro.Instructions;
using System.Collections;

namespace CILantro.Interpreting
{
    public class CilMethodState
    {
        public CilInstruction Instruction { get; set; }

        public Stack EvaluationStack { get; set; }
    }
}