using CILantro.Instructions;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.State;
using CILantro.Structure;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class CilInterpreterInstructionsVisitor : CilInstructionsVisitor
    {
        private readonly CilExecutionState _executionState;

        private readonly InstructionNoneInterpreterVisitor _instructionNoneVisitor;

        private readonly InstructionMethodInterpreterVisitor _instructionMethodVisitor;

        private readonly InstructionStringInterpreterVisitor _instructionStringVisitor;

        private readonly InstructionIInterpreterVisitor _instructionIVisitor;

        private readonly InstructionTypeInterpreterVisitor _instructionTypeVisitor;

        private readonly InstructionVarInterpreterVisitor _instructionVarVisitor;

        private readonly InstructionRInterpreterVisitor _instructionRVisitor;

        private readonly InstructionBrInterpreterVisitor _instructionBrVisitor;

        private readonly InstructionFieldInterpreterVisitor _instructionFieldVisitor;

        private readonly InstructionI8InterpreterVisitor _instructionI8InterpreterVisitor;

        private readonly InstructionSwitchInterpreterVisitor _instructionSwitchInterpreterVisitor;

        private readonly InstructionTokInterpreterVisitor _instructionTokInterpreterVisitor;

        protected override InstructionNoneVisitor InstructionNoneVisitor => _instructionNoneVisitor;

        protected override InstructionMethodVisitor InstructionMethodVisitor => _instructionMethodVisitor;

        protected override InstructionStringVisitor InstructionStringVisitor => _instructionStringVisitor;

        protected override InstructionIVisitor InstructionIVisitor => _instructionIVisitor;

        protected override InstructionTypeVisitor InstructionTypeVisitor => _instructionTypeVisitor;

        protected override InstructionVarVisitor InstructionVarVisitor => _instructionVarVisitor;

        protected override InstructionRVisitor InstructionRVisitor => _instructionRVisitor;

        protected override InstructionBrVisitor InstructionBrVisitor => _instructionBrVisitor;

        protected override InstructionFieldVisitor InstructionFieldVisitor => _instructionFieldVisitor;

        protected override InstructionI8Visitor InstructionI8Visitor => _instructionI8InterpreterVisitor;

        protected override InstructionSwitchVisitor InstructionSwitchVisitor => _instructionSwitchInterpreterVisitor;

        protected override InstructionTokVisitor InstructionTokVisitor => _instructionTokInterpreterVisitor;

        public CilInterpreterInstructionsVisitor(CilProgram program)
        {
            var state = new CilControlState(program);
            var managedMemory = new CilDictionaryManagedMemory();

            _executionState = new CilExecutionState
            {
                ControlState = state,
                ManagedMemory = managedMemory
            };

            _instructionNoneVisitor = new InstructionNoneInterpreterVisitor(program, _executionState);
            _instructionMethodVisitor = new InstructionMethodInterpreterVisitor(program, _executionState);
            _instructionStringVisitor = new InstructionStringInterpreterVisitor(program, _executionState);
            _instructionIVisitor = new InstructionIInterpreterVisitor(program, _executionState);
            _instructionTypeVisitor = new InstructionTypeInterpreterVisitor(program, _executionState);
            _instructionVarVisitor = new InstructionVarInterpreterVisitor(program, _executionState);
            _instructionRVisitor = new InstructionRInterpreterVisitor(program, _executionState);
            _instructionBrVisitor = new InstructionBrInterpreterVisitor(program, _executionState);
            _instructionFieldVisitor = new InstructionFieldInterpreterVisitor(program, _executionState);
            _instructionI8InterpreterVisitor = new InstructionI8InterpreterVisitor(program, _executionState);
            _instructionSwitchInterpreterVisitor = new InstructionSwitchInterpreterVisitor(program, _executionState);
            _instructionTokInterpreterVisitor = new InstructionTokInterpreterVisitor(program, _executionState);
        }

        protected override CilInstruction GetNextInstruction()
        {
            return _executionState.ControlState.Instruction;
        }
    }
}