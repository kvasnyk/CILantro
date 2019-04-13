using CILantro.Instructions.Method;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.State;
using CILantro.Structure;
using CILantro.Utils;
using CILantro.Visitors;
using System.Collections.Generic;
using System.Linq;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionMethodInterpreterVisitor : InstructionMethodVisitor
    {
        private readonly CilControlState _state;

        private readonly CilHeap _heap;

        public InstructionMethodInterpreterVisitor(CilControlState state, CilHeap heap)
        {
            _state = state;
            _heap = heap;
        }

        public override void VisitCallInstruction(CallInstruction instruction)
        {
            var methodArguments = new List<object>();
            for (int i = 0; i < instruction.SigArgs.Count; i++)
            {
                var argument = _state.CurrentEvaluationStack.Pop();

                var methodArgument = argument is CilReference referenceArgument ?
                    _heap.Load(referenceArgument.Address) :
                    (argument as CilValue).GetValue();

                methodArguments.Add(methodArgument);
            }
            methodArguments.Reverse();

            var callConfig = new MethodCallerConfig
            {
                AssemblyName = instruction.TypeSpec.ClassName.AssemblyName,
                ClassName = instruction.TypeSpec.ClassName.ClassName,
                MethodName = instruction.MethodName,
                Arguments = methodArguments.ToArray(),
                Types = instruction.SigArgs.Select(sa => sa.Type.GetRuntimeType()).ToArray()
            };

            var result = MethodCaller.Call(callConfig);

            if (!(instruction.ReturnType is CilTypeVoid))
            {
                var resultAddress = _heap.Store(result);
                var resultRef = new CilReference(resultAddress);

                _state.CurrentEvaluationStack.Push(resultRef);
            }

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }
    }
}