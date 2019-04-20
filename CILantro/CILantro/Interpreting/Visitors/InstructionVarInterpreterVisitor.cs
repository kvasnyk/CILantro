using CILantro.Instructions.Var;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.State;
using CILantro.Structure;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionVarInterpreterVisitor : InstructionVarVisitor
    {
        private readonly CilControlState _state;

        private readonly CilManagedMemory _managedMemory;

        private readonly CilProgram _program;

        public InstructionVarInterpreterVisitor(CilProgram program, CilControlState state, CilManagedMemory managedMemory)
        {
            _state = state;
            _managedMemory = managedMemory;
            _program = program;
        }

        protected override void VisitLoadLocalShortInstruction(LoadLocalShortInstruction instruction)
        {
            // TODO: finish implementation

            //var value = _state.Locals.Load(instruction.Id);
            //_state.EvaluationStack.Push(value);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitStoreLocalShortInstruction(StoreLocalShortInstruction instruction)
        {
            var localType = _state.Locals.GetLocalType(instruction.Id, instruction.Index);
            _state.EvaluationStack.PopValue(_program, localType, out var value);
            _state.Locals.Store(instruction.Id, instruction.Index, value);

            _state.MoveToNextInstruction();
        }
    }
}