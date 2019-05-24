using CILantro.Instructions;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.State;
using CILantro.Structure;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class CilInterpreterInstructionsVisitor : CilInstructionsVisitor
    {
        private readonly CilControlState _state;

        private readonly CilManagedMemory _managedMemory;

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
            _state = new CilControlState(program);
            _managedMemory = new CilDictionaryManagedMemory();

            _instructionNoneVisitor = new InstructionNoneInterpreterVisitor(program, _state, _managedMemory);
            _instructionMethodVisitor = new InstructionMethodInterpreterVisitor(program, _state, _managedMemory);
            _instructionStringVisitor = new InstructionStringInterpreterVisitor(_state, _managedMemory);
            _instructionIVisitor = new InstructionIInterpreterVisitor(_state, _managedMemory);
            _instructionTypeVisitor = new InstructionTypeInterpreterVisitor(program, _state, _managedMemory);
            _instructionVarVisitor = new InstructionVarInterpreterVisitor(program, _state, _managedMemory);
            _instructionRVisitor = new InstructionRInterpreterVisitor(_state, _managedMemory);
            _instructionBrVisitor = new InstructionBrInterpreterVisitor(_state, _managedMemory);
            _instructionFieldVisitor = new InstructionFieldInterpreterVisitor(program, _state, _managedMemory);
            _instructionI8InterpreterVisitor = new InstructionI8InterpreterVisitor(_state, _managedMemory);
            _instructionSwitchInterpreterVisitor = new InstructionSwitchInterpreterVisitor(_state, _managedMemory);
            _instructionTokInterpreterVisitor = new InstructionTokInterpreterVisitor(program, _state, _managedMemory);
        }

        protected override CilInstruction GetNextInstruction()
        {
            return _state.Instruction;
        }
    }
}