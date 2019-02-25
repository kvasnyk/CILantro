using CILantro.Interpreting;
using CILantro.Utils;

namespace CILantro.Instructions.Method
{
    public class CallInstruction : CilInstructionMethod
    {
        public override void Execute(CilControlState state)
        {
            var methodArgument = state.CurrentEvaluationStack.Pop();

            var callConfig = new MethodCallerConfig
            {
                AssemblyName = TypeSpec.ClassName.AssemblyName,
                ClassName = TypeSpec.ClassName.ClassName,
                MethodName = MethodName,
                Arguments = new object[] { methodArgument }
            };

            MethodCaller.Call(callConfig);

            state.CurrentMethodState.Instruction = state.CurrentMethod.GetNextInstruction(this);
        }

        public override string ToString()
        {
            return "call";
        }
    }
}