using CILantro.Instructions.Field;
using CILantro.Interpreting.Instances;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.State;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using CILantro.Utils;
using CILantro.Visitors;
using System.Reflection;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionFieldInterpreterVisitor : InstructionFieldVisitor
    {
        private readonly CilExecutionState _executionState;

        private readonly CilProgram _program;

        private CilControlState ControlState => _executionState.ControlState;

        private CilManagedMemory ManagedMemory => _executionState.ManagedMemory;

        public InstructionFieldInterpreterVisitor(CilProgram program, CilExecutionState executionState)
        {
            _executionState = executionState;

            _program = program;
        }

        protected override void VisitLoadFieldAddressInstruction(LoadFieldAddressInstruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference thisRef);

            var classInstance = ManagedMemory.Load(thisRef) as CilClassInstance;
            var fieldValue = classInstance.Fields[instruction.FieldId];
            var fieldPointer = new CilValueManagedPointer(fieldValue);

            ControlState.EvaluationStack.PushValue(fieldPointer);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadFieldInstruction(LoadFieldInstruction instruction)
        {
            ControlState.EvaluationStack.PopValue(_program, instruction.ClassTypeSpec.GetCilType(_program), out var instanceVal);

            CilClassInstance classInstance = null;
            if (instanceVal is CilValueValueType instanceValValueType)
                classInstance = instanceValValueType.Value;
            else if (instanceVal is CilValueReference instanceValReference)
                classInstance = ManagedMemory.Load(instanceValReference) as CilClassInstance;
            else
                throw new System.NotImplementedException();

            var value = classInstance.Fields[instruction.FieldId];

            ControlState.EvaluationStack.PushValue(value);

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitLoadStaticFieldInstruction(LoadStaticFieldInstruction instruction)
        {
            if (_program.IsExternalType(instruction.ClassTypeSpec.ClassName))
            {
                var @class = ReflectionHelper.GetExternalType(instruction.ClassTypeSpec.ClassName);
                var field = @class.GetField(instruction.FieldId, BindingFlags.Static | BindingFlags.Public);
                var externalValue = field.GetValue(null);
                var value = instruction.FieldType.CreateValueFromRuntime(externalValue, ManagedMemory, _program);

                ControlState.EvaluationStack.PushValue(value);

                ControlState.MoveToNextInstruction();
            }
            else
            {
                var value = ControlState.StaticInstances[instruction.ClassTypeSpec.ClassName.ToString()].StaticFields[instruction.FieldId];

                ControlState.EvaluationStack.PushValue(value);

                ControlState.MoveToNextInstruction();
            }
        }

        protected override void VisitStoreFieldInstruction(StoreFieldInstruction instruction)
        {
            ControlState.EvaluationStack.PopValue(_program, instruction.FieldType, out var value);
            ControlState.EvaluationStack.PopValue(_program, instruction.ClassTypeSpec.GetCilType(_program), out var instanceVal);

            CilClassInstance classInstance = null;
            if (instanceVal is CilValueValueType instanceValValueType)
                classInstance = instanceValValueType.Value;
            else if (instanceVal is CilValueReference instanceValReference)
                classInstance = ManagedMemory.Load(instanceValReference) as CilClassInstance;
            else
                throw new System.NotImplementedException();

            classInstance.Fields[instruction.FieldId] = value;

            ControlState.MoveToNextInstruction();
        }

        protected override void VisitStoreStaticFieldInstruction(StoreStaticFieldInstruction instruction)
        {
            ControlState.EvaluationStack.PopValue(_program, instruction.FieldType, out var value);

            ControlState.StaticInstances[instruction.ClassTypeSpec.ClassName.ToString()].StaticFields[instruction.FieldId] = value;

            ControlState.MoveToNextInstruction();
        }
    }
}