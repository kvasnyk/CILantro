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

        private readonly CilHeap _heap;

        private readonly InstructionNoneInterpreterVisitor _instructionNoneVisitor;

        private readonly InstructionMethodInterpreterVisitor _instructionMethodVisitor;

        private readonly InstructionStringInterpreterVisitor _instructionStringVisitor;

        private readonly InstructionIInterpreterVisitor _instructionIVisitor;

        protected override InstructionNoneVisitor InstructionNoneVisitor => _instructionNoneVisitor;

        protected override InstructionMethodVisitor InstructionMethodVisitor => _instructionMethodVisitor;

        protected override InstructionStringVisitor InstructionStringVisitor => _instructionStringVisitor;

        protected override InstructionIVisitor InstructionIVisitor => _instructionIVisitor;

        public CilInterpreterInstructionsVisitor(CilProgram program)
        {
            _state = new CilControlState(program.EntryPoint);
            _heap = new CilDictionaryHeap();

            _instructionNoneVisitor = new InstructionNoneInterpreterVisitor(_state, _heap);
            _instructionMethodVisitor = new InstructionMethodInterpreterVisitor(_state, _heap);
            _instructionStringVisitor = new InstructionStringInterpreterVisitor(_state, _heap);
            _instructionIVisitor = new InstructionIInterpreterVisitor(_state, _heap);
        }

        protected override CilInstruction GetNextInstruction()
        {
            return _state.CurrentInstruction;
        }
    }
}