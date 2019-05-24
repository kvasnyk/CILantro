using CILantro.Instructions.Switch;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.State;
using CILantro.Interpreting.Values;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionSwitchInterpreterVisitor : InstructionSwitchVisitor
    {
        private readonly CilControlState _state;

        private readonly CilManagedMemory _managedMemory;

        public InstructionSwitchInterpreterVisitor(CilControlState state, CilManagedMemory managedMemory)
        {
            _state = state;
            _managedMemory = managedMemory;
        }

        protected override void VisitSwitchInstruction(SwitchInstruction instruction)
        {
            _state.EvaluationStack.PopValue(out CilValueUInt32 value);

            if (value.Value < instruction.SwitchLabels.Count)
            {
                var targetLabel = instruction.SwitchLabels[(int)value.Value];
                _state.Move(targetLabel.Offset, targetLabel.Id);
            }
            else
            {
                _state.MoveToNextInstruction();
            }
        }
    }
}