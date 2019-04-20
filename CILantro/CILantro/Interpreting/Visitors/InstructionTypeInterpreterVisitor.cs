using CILantro.Instructions.Type;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.State;
using CILantro.Interpreting.Values;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionTypeInterpreterVisitor : InstructionTypeVisitor
    {
        private readonly CilControlState _state;

        private readonly CilManagedMemory _managedMemory;

        public InstructionTypeInterpreterVisitor(CilControlState state, CilManagedMemory managedMemory)
        {
            _state = state;
            _managedMemory = managedMemory;
        }

        public override void VisitNewArrayInstruction(NewArrayInstruction instruction)
        {
            // TODO: finish implementation
            // TODO: can we really use Array class?
            // TODO: and do we really need to use Array class?

            _state.EvaluationStack.PopValue(out CilValueInt32 numElems);

            var newArr = new CilArray(instruction.TypeSpec.GetCilType(), numElems.Value);
            var arrRef = _managedMemory.Store(newArr);

            _state.EvaluationStack.PushValue(arrRef);

            _state.MoveToNextInstruction();
        }
    }
}