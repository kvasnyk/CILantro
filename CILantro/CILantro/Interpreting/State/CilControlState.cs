using CILantro.Instructions;
using CILantro.Interpreting.Objects;
using CILantro.Structure;
using System.Collections.Generic;
using System.Linq;

namespace CILantro.Interpreting.State
{
    public class CilControlState
    {
        public Stack<CilCallStackItem> CallStack { get; set; }

        public CilMethod CurrentMethod => CallStack.Peek().Method;

        public CilMethodState CurrentMethodState => CallStack.Peek().MethodState;

        public CilInstruction CurrentInstruction => CurrentMethodState.Instruction;

        public Stack<CilObject> CurrentEvaluationStack => CurrentMethodState.EvaluationStack;

        public CilControlState(CilMethod entryPoint)
        {
            CallStack = new Stack<CilCallStackItem>();
            CallStack.Push(new CilCallStackItem
            {
                Method = entryPoint,
                MethodState = new CilMethodState
                {
                    Instruction = entryPoint.Instructions.First(),
                    EvaluationStack = new Stack<CilObject>()
                }
            });
        }
    }
}