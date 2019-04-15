using CILantro.Instructions;
using CILantro.Structure;
using System.Collections.Generic;

namespace CILantro.Interpreting.State
{
    public class CilControlState
    {
        public Stack<CilMethodState> CallStack { get; set; }

        public CilMethodState MethodState => CallStack.Peek();

        public CilInstruction Instruction => MethodState.Instruction;

        public CilEvaluationStack EvaluationStack => MethodState.EvaluationStack;

        public CilMethodInfo MethodInfo => MethodState.MethodInfo;

        public CilLocals Locals => MethodState.Locals;

        public CilControlState(CilMethod entryPoint)
        {
            CallStack = new Stack<CilMethodState>();
            CallStack.Push(new CilMethodState(entryPoint));
        }

        public void MoveToNextInstruction()
        {
            MethodState.Instruction = MethodInfo.GetNextInstruction(Instruction);
        }
    }
}