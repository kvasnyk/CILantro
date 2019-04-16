using CILantro.Instructions.I;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.State;
using CILantro.Interpreting.Values;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionIInterpreterVisitor : InstructionIVisitor
    {
        private readonly CilControlState _state;

        private readonly CilManagedMemory _managedMemory;

        public InstructionIInterpreterVisitor(CilControlState state, CilManagedMemory managedMemory)
        {
            _state = state;
            _managedMemory = managedMemory;
        }

        protected override void VisitLoadConstI4ShortInstruction(LoadConstI4ShortInstruction instruction)
        {
            // TODO: finish implementation

            var value = new CilValueInt32(instruction.Value);
            _state.EvaluationStack.Push(value);

            _state.MoveToNextInstruction();
        }
    }
}