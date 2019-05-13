using CILantro.Instructions.I8;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackValues;
using CILantro.Interpreting.State;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionI8InterpreterVisitor : InstructionI8Visitor
    {
        private readonly CilControlState _state;

        private readonly CilManagedMemory _managedMemory;

        public InstructionI8InterpreterVisitor(CilControlState state, CilManagedMemory managedMemory)
        {
            _state = state;
            _managedMemory = managedMemory;
        }

        protected override void VisitLoadConstI8Instruction(LoadConstI8Instruction instruction)
        {
            var stackVal = new CilStackValueInt64(instruction.Value);
            _state.EvaluationStack.Push(stackVal);

            _state.MoveToNextInstruction();
        }
    }
}