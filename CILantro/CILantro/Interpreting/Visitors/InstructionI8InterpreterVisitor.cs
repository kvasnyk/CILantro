using CILantro.Instructions.I8;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackValues;
using CILantro.Interpreting.State;
using CILantro.Structure;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionI8InterpreterVisitor : InstructionI8Visitor
    {
        private readonly CilExecutionState _executionState;

        private readonly CilProgram _program;

        private CilControlState ControlState => _executionState.ControlState;

        private CilManagedMemory ManagedMemory => _executionState.ManagedMemory;

        public InstructionI8InterpreterVisitor(CilProgram program, CilExecutionState executionState)
        {
            _executionState = executionState;

            _program = program;
        }

        protected override void VisitLoadConstI8Instruction(LoadConstI8Instruction instruction)
        {
            var stackVal = new CilStackValueInt64(instruction.Value);
            ControlState.EvaluationStack.Push(stackVal);

            ControlState.MoveToNextInstruction();
        }
    }
}