using CILantro.Instructions.Var;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.State;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionVarInterpreterVisitor : InstructionVarVisitor
    {
        private readonly CilControlState _state;

        private readonly CilManagedMemory _managedMemory;

        public InstructionVarInterpreterVisitor(CilControlState state, CilManagedMemory managedMemory)
        {
            _state = state;
            _managedMemory = managedMemory;
        }

        protected override void VisitLoadLocalShortInstruction(LoadLocalShortInstruction instruction)
        {
            // TODO: finish implementation

            var value = _state.Locals.Load(instruction.Id);
            _state.EvaluationStack.Push(value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreLocalShortInstruction(StoreLocalShortInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out var value);
            _state.Locals.Store(instruction.Id, value);

            _state.MoveToNextInstruction();
        }
    }
}