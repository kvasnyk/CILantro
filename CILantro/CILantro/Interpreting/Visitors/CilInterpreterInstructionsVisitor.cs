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

        protected override InstructionNoneVisitor InstructionNoneVisitor => _instructionNoneVisitor;

        protected override InstructionMethodVisitor InstructionMethodVisitor => _instructionMethodVisitor;

        protected override InstructionStringVisitor InstructionStringVisitor => _instructionStringVisitor;

        protected override InstructionIVisitor InstructionIVisitor => _instructionIVisitor;

        protected override InstructionTypeVisitor InstructionTypeVisitor => _instructionTypeVisitor;

        protected override InstructionVarVisitor InstructionVarVisitor => _instructionVarVisitor;

        protected override InstructionRVisitor InstructionRVisitor => _instructionRVisitor;

        protected override InstructionBrVisitor InstructionBrVisitor => _instructionBrVisitor;

        public CilInterpreterInstructionsVisitor(CilProgram program)
        {
            _state = new CilControlState(program.EntryPoint);
            _managedMemory = new CilDictionaryManagedMemory();

            _instructionNoneVisitor = new InstructionNoneInterpreterVisitor(program, _state, _managedMemory);
            _instructionMethodVisitor = new InstructionMethodInterpreterVisitor(program, _state, _managedMemory);
            _instructionStringVisitor = new InstructionStringInterpreterVisitor(_state, _managedMemory);
            _instructionIVisitor = new InstructionIInterpreterVisitor(_state, _managedMemory);
            _instructionTypeVisitor = new InstructionTypeInterpreterVisitor(program, _state, _managedMemory);
            _instructionVarVisitor = new InstructionVarInterpreterVisitor(program, _state, _managedMemory);
            _instructionRVisitor = new InstructionRInterpreterVisitor(_state, _managedMemory);
            _instructionBrVisitor = new InstructionBrInterpreterVisitor(_state, _managedMemory);
        }

        protected override CilInstruction GetNextInstruction()
        {
            return _state.Instruction;
        }
    }
}