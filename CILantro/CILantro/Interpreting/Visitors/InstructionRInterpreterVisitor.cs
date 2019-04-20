using CILantro.Instructions.R;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.State;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionRInterpreterVisitor : InstructionRVisitor
    {
        private readonly CilControlState _state;

        private readonly CilManagedMemory _managedMemory;

        public InstructionRInterpreterVisitor(CilControlState state, CilManagedMemory managedMemory)
        {
            _state = state;
            _managedMemory = managedMemory;
        }

        protected override void VisitLoadConstR4Instruction(LoadConstR4Instruction instruction)
        {
            // TODO: finish implementation

            //var value = new CilValueFloat32((float)instruction.Value);
            //_state.EvaluationStack.Push(value);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitLoadConstR8Instruction(LoadConstR8Instruction instruction)
        {
            // TODO: finish implementation

            //var value = new CilValueFloat64(instruction.Value);
            //_state.EvaluationStack.Push(value);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }
    }
}