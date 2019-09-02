using CILantro.Instructions.R;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.State;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionRInterpreterVisitor : InstructionRVisitor
    {
        private readonly CilExecutionState _executionState;

        private readonly CilProgram _program;

        private CilControlState ControlState => _executionState.ControlState;

        private CilManagedMemory ManagedMemory => _executionState.ManagedMemory;

        public InstructionRInterpreterVisitor(CilProgram program, CilExecutionState executionState)
        {
            _executionState = executionState;

            _program = program;
        }

        protected override void VisitLoadConstR4Instruction(LoadConstR4Instruction instruction)
        {
            var value = new CilValueFloat32((float)instruction.Value);
            ControlState.EvaluationStack.PushValue(value);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadConstR8Instruction(LoadConstR8Instruction instruction)
        {
            var value = new CilValueFloat64(instruction.Value);
            ControlState.EvaluationStack.PushValue(value);

            ControlState.MoveToNextInstruction();
        }
    }
}