using CILantro.Instructions.Method;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.State;
using CILantro.Utils;
using CILantro.Visitors;

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
            var argument = _state.CurrentEvaluationStack.Pop();
            var methodArgument = _heap.Load((argument as CilReference).Address);

            var callConfig = new MethodCallerConfig
            {
                AssemblyName = instruction.TypeSpec.ClassName.AssemblyName,
                ClassName = instruction.TypeSpec.ClassName.ClassName,
                MethodName = instruction.MethodName,
                Arguments = new object[] { methodArgument }
            };

            MethodCaller.Call(callConfig);

            _state.CurrentMethodState.Instruction = _state.CurrentMethod.GetNextInstruction(instruction);
        }
    }
}