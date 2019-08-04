using CILantro.Instructions.Switch;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.State;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionSwitchInterpreterVisitor : InstructionSwitchVisitor
    {
        private readonly CilExecutionState _executionState;

        private readonly CilProgram _program;

        private CilControlState ControlState => _executionState.ControlState;

        private CilManagedMemory ManagedMemory => _executionState.ManagedMemory;

        public InstructionSwitchInterpreterVisitor(CilProgram program, CilExecutionState executionState)
        {
            _executionState = executionState;

            _program = program;
        }

        protected override void VisitSwitchInstruction(SwitchInstruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueUInt32 value);

            if (value.Value < instruction.SwitchLabels.Count)
            {
                var targetLabel = instruction.SwitchLabels[(int)value.Value];
                ControlState.Move(targetLabel.Offset, targetLabel.Id);
            }
            else
            {
                ControlState.MoveToNextInstruction();
            }
        }
    }
}