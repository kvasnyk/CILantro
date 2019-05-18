using CILantro.Instructions.Field;
using CILantro.Interpreting.Instances;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.State;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionFieldInterpreterVisitor : InstructionFieldVisitor
    {
        private readonly CilControlState _state;

        private readonly CilManagedMemory _managedMemory;

        private readonly CilProgram _program;

        public InstructionFieldInterpreterVisitor(CilProgram program, CilControlState state, CilManagedMemory managedMemory)
        {
            _program = program;
            _state = state;
            _managedMemory = managedMemory;
        }

        protected override void VisitLoadFieldInstruction(LoadFieldInstruction instruction)
        {
            _state.EvaluationStack.PopValue(out CilValueReference thisRef);

            var classInstance = _managedMemory.Load(thisRef) as CilClassInstance;
            var value = classInstance.Fields[instruction.FieldId];

            _state.EvaluationStack.PushValue(value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadStaticFieldInstruction(LoadStaticFieldInstruction instruction)
        {
            var value = _state.StaticInstances[instruction.ClassTypeSpec.ClassName.ToString()].StaticFields[instruction.FieldId];

            _state.EvaluationStack.PushValue(value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreFieldInstruction(StoreFieldInstruction instruction)
        {
            _state.EvaluationStack.PopValue(_program, instruction.FieldType, out var value);
            _state.EvaluationStack.PopValue(out CilValueReference thisRef);

            var classInstance = _managedMemory.Load(thisRef) as CilClassInstance;
            classInstance.Fields[instruction.FieldId] = value;

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreStaticFieldInstruction(StoreStaticFieldInstruction instruction)
        {
            _state.EvaluationStack.PopValue(_program, instruction.FieldType, out var value);

            _state.StaticInstances[instruction.ClassTypeSpec.ClassName.ToString()].StaticFields[instruction.FieldId] = value;

            _state.MoveToNextInstruction();
        }
    }
}