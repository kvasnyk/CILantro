using CILantro.Instructions;
using CILantro.Structure;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class CilInterpreterInstructionsVisitor : CilInstructionsVisitor
    {
        private readonly CilControlState _state;

        private readonly InstructionNoneInterpreterVisitor _instructionNoneVisitor;

        private readonly InstructionMethodInterpreterVisitor _instructionMethodVisitor;

        private readonly InstructionStringInterpreterVisitor _instructionStringVisitor;

        protected override InstructionNoneVisitor InstructionNoneVisitor => _instructionNoneVisitor;

        protected override InstructionMethodVisitor InstructionMethodVisitor => _instructionMethodVisitor;

        protected override InstructionStringVisitor InstructionStringVisitor => _instructionStringVisitor;

        public CilInterpreterInstructionsVisitor(CilProgram program)
        {
            _state = new CilControlState(program.EntryPoint);

            _instructionNoneVisitor = new InstructionNoneInterpreterVisitor(_state);
            _instructionMethodVisitor = new InstructionMethodInterpreterVisitor(_state);
            _instructionStringVisitor = new InstructionStringInterpreterVisitor(_state);
        }

        protected override CilInstruction GetNextInstruction()
        {
            return _state.CurrentInstruction;
        }
    }
}