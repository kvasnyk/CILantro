using CILantro.Instructions.Field;
using CILantro.Interpreting.Instances;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.State;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using CILantro.Visitors;
using System.Reflection;

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

        protected override void VisitLoadFieldAddressInstruction(LoadFieldAddressInstruction instruction)
        {
            _state.EvaluationStack.PopValue(out CilValueReference thisRef);

            var classInstance = _managedMemory.Load(thisRef) as CilClassInstance;
            var fieldValue = classInstance.Fields[instruction.FieldId];
            var fieldPointer = new CilValueManagedPointer(fieldValue);

            _state.EvaluationStack.PushValue(fieldPointer);

            _state.MoveToNextInstruction();
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
            if (_program.IsExternalType(instruction.ClassTypeSpec.ClassName))
            {
                var assembly = Assembly.Load(instruction.ClassTypeSpec.ClassName.AssemblyName);
                var @class = assembly.GetType(instruction.ClassTypeSpec.ClassName.ClassName);
                var field = @class.GetField(instruction.FieldId, BindingFlags.Static | BindingFlags.Public);
                var externalValue = field.GetValue(null);
                var value = instruction.FieldType.CreateValueFromRuntime(externalValue, _managedMemory, _program);

                _state.EvaluationStack.PushValue(value);

                _state.MoveToNextInstruction();
            }
            else
            {
                var value = _state.StaticInstances[instruction.ClassTypeSpec.ClassName.ToString()].StaticFields[instruction.FieldId];

                _state.EvaluationStack.PushValue(value);

                _state.MoveToNextInstruction();
            }
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