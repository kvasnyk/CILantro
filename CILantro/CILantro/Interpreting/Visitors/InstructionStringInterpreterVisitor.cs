using CILantro.Instructions.String;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.State;
using CILantro.Structure;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionStringInterpreterVisitor : InstructionStringVisitor
    {
        private readonly CilExecutionState _executionState;

        private readonly CilProgram _program;

        private CilControlState ControlState => _executionState.ControlState;

        private CilManagedMemory ManagedMemory => _executionState.ManagedMemory;

        public InstructionStringInterpreterVisitor(CilProgram program, CilExecutionState executionState)
        {
            _executionState = executionState;

            _program = program;
        }

        protected override void VisitLoadStringInstruction(LoadStringInstruction instruction)
        {
            // TODO: finish implementation

            var cilString = new CilString(instruction.StringValue);

            var reference = ManagedMemory.Store(cilString);
            ControlState.EvaluationStack.PushValue(reference);

            ControlState.MoveToNextInstruction();
        }
    }
}