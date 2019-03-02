using CILantro.Instructions.Method;
using CILantro.Utils;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionMethodInterpreterVisitor : InstructionMethodVisitor
    {
        private readonly CilControlState _state;

        public InstructionMethodInterpreterVisitor(CilControlState state)
        {
            _state = state;
        }

        public override void VisitCallInstruction(CallInstruction instruction)
        {
            var methodArgument = _state.CurrentEvaluationStack.Pop();

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