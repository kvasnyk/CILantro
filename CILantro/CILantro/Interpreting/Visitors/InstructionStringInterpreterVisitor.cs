using CILantro.Instructions.String;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.State;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionStringInterpreterVisitor : InstructionStringVisitor
    {
        private readonly CilControlState _state;

        private readonly CilManagedMemory _managedMemory;

        public InstructionStringInterpreterVisitor(CilControlState state, CilManagedMemory managedMemory)
        {
            _state = state;
            _managedMemory = managedMemory;
        }

        protected override void VisitLoadStringInstruction(LoadStringInstruction instruction)
        {
            // TODO: finish implementation

            var cilString = new CilString(instruction.StringValue);

            var reference = _managedMemory.Store(cilString);
            _state.EvaluationStack.PushValue(reference);

            _state.MoveToNextInstruction();
        }
    }
}