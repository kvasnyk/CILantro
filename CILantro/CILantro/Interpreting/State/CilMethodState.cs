using CILantro.Instructions;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System.Collections.Generic;
using System.Linq;

namespace CILantro.Interpreting.State
{
    public class CilMethodState
    {
        public CilInstruction Instruction { get; set; }

        public CilEvaluationStack EvaluationStack { get; set; }

        public CilMethodInfo MethodInfo { get; set; }

        public CilOrderedDictionary Locals { get; set; }

        public CilOrderedDictionary Arguments { get; set; }

        public CilMethodState(CilMethod method, List<CilSigArg> argTypes, List<IValue> argValues)
        {
            Instruction = method.Instructions.First();
            EvaluationStack = new CilEvaluationStack();
            MethodInfo = new CilMethodInfo(method);
            Locals = new CilOrderedDictionary(method.Locals);

            Arguments = new CilOrderedDictionary(argTypes);
            for (int i = 0; i < argValues.Count; i++)
            {
                Arguments.Store(null, i, argValues[i]);
            }
        }
    }
}