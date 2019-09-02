using CILantro.Instructions.Var;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.State;
using CILantro.Structure;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionVarInterpreterVisitor : InstructionVarVisitor
    {
        private readonly CilExecutionState _executionState;

        private readonly CilProgram _program;

        private CilControlState ControlState => _executionState.ControlState;

        private CilManagedMemory ManagedMemory => _executionState.ManagedMemory;

        public InstructionVarInterpreterVisitor(CilProgram program, CilExecutionState executionState)
        {
            _executionState = executionState;

            _program = program;
        }

        protected override void VisitLoadArgumentShortInstruction(LoadArgumentShortInstruction instruction)
        {
            var value = ControlState.Arguments.Load(instruction.Id, instruction.Index);
            ControlState.EvaluationStack.PushValue(value);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadLocalAddressShortInstruction(LoadLocalAddressShortInstruction instruction)
        {
            var address = ControlState.Locals.LoadAddress(instruction.Id, instruction.Index);
            ControlState.EvaluationStack.PushValue(address);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadLocalShortInstruction(LoadLocalShortInstruction instruction)
        {
            var value = ControlState.Locals.Load(instruction.Id, instruction.Index);
            ControlState.EvaluationStack.PushValue(value);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitStoreArgumentShortInstruction(StoreArgumentShortInstruction instruction)
        {
            var argType = ControlState.Arguments.GetLocalType(instruction.Id, instruction.Index);
            ControlState.EvaluationStack.PopValue(_program, argType, out var value);
            ControlState.Arguments.Store(instruction.Id, instruction.Index, value);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitStoreLocalShortInstruction(StoreLocalShortInstruction instruction)
        {
            var localType = ControlState.Locals.GetLocalType(instruction.Id, instruction.Index);
            ControlState.EvaluationStack.PopValue(_program, localType, out var value);
            ControlState.Locals.Store(instruction.Id, instruction.Index, value);

            ControlState.MoveToNextInstruction();
        }
    }
}