using CILantro.Instructions.I;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackValues;
using CILantro.Interpreting.State;
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
            var stackVal = new CilStackValueInt32(instruction.Value);
            _state.EvaluationStack.Push(stackVal);

            _state.MoveToNextInstruction();
        }
    }
}