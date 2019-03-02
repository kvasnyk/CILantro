using CILantro.Instructions;
using CILantro.Interpreting.Objects;
using System.Collections.Generic;

namespace CILantro.Interpreting.State
{
    public class CilMethodState
    {
        public CilInstruction Instruction { get; set; }

        public Stack<CilObject> EvaluationStack { get; set; }

        public CilMethodInfo MethodInfo { get; set; }
    }
}