using CILantro.Instructions;
using CILantro.Interpreting.Objects;
using CILantro.Structure;
using System.Collections.Generic;
using System.Linq;

namespace CILantro.Interpreting.State
{
    public class CilControlState
    {
        public Stack<CilMethodState> CallStack { get; set; }

        public CilMethodState CurrentMethodState => CallStack.Peek();

        public CilInstruction CurrentInstruction => CurrentMethodState.Instruction;

        public Stack<CilObject> CurrentEvaluationStack => CurrentMethodState.EvaluationStack;

        public CilMethodInfo CurrentMethodInfo => CurrentMethodState.MethodInfo;

        public CilMethodLocals CurrentLocals => CurrentMethodState.Locals;

        public CilControlState(CilMethod entryPoint)
        {
            CallStack = new Stack<CilMethodState>();
            CallStack.Push(new CilMethodState
            {
                Instruction = entryPoint.Instructions.First(),
                EvaluationStack = new Stack<CilObject>(),
                MethodInfo = new CilMethodInfo(entryPoint),
                Locals = new CilMethodLocals()
            });
        }
    }
}