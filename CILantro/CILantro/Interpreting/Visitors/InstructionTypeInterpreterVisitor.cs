using CILantro.Instructions.Type;
using CILantro.Interpreting.Instances;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.State;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionTypeInterpreterVisitor : InstructionTypeVisitor
    {
        private readonly CilExecutionState _executionState;

        private readonly CilProgram _program;

        private CilControlState ControlState => _executionState.ControlState;

        private CilManagedMemory ManagedMemory => _executionState.ManagedMemory;

        public InstructionTypeInterpreterVisitor(CilProgram program, CilExecutionState executionState)
        {
            _executionState = executionState;

            _program = program;
        }

        public override void VisitBoxInstruction(BoxInstruction instruction)
        {
            var cilType = instruction.TypeSpec.GetCilType(_program);
            ControlState.EvaluationStack.PopValue(_program, cilType, out var val);

            CilObject obj = null;
            if (cilType.IsValueType(_program) && !cilType.IsNullable)
            {
                obj = val.Box();
            }

            var objRef = ManagedMemory.Store(obj);
            ControlState.EvaluationStack.PushValue(objRef);

            ControlState.MoveToNextInstruction();
        }

        public override void VisitInitObjectInstruction(InitObjectInstruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueManagedPointer pointer);

            var type = instruction.TypeSpec.GetCilType(_program);
            var empty = type.CreateDefaultValue(_program);
            pointer.ValueToRef = empty;

            ControlState.MoveToNextInstruction();
        }

        public override void VisitIsInstanceInstruction(IsInstanceInstruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference objRef);
            var obj = ManagedMemory.Load(objRef);

            if (obj is CilClassInstance objClassInstance)
            {
                if (objClassInstance.IsInstanceOf(instruction.TypeSpec, _program))
                    ControlState.EvaluationStack.PushValue(objRef);
                else
                    ControlState.EvaluationStack.PushValue(new CilValueNull());
            }
            else
            {
                throw new System.NotImplementedException();
            }

            ControlState.MoveToNextInstruction();
        }

        public override void VisitLoadArrayElementInstruction(LoadArrayElementInstruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, instruction.TypeSpec.GetCilType(_program), ManagedMemory, _program);

            ControlState.EvaluationStack.PushValue(elem);
            ControlState.MoveToNextInstruction();
        }

        public override void VisitNewArrayInstruction(NewArrayInstruction instruction)
        {
            // TODO: finish implementation
            // TODO: can we really use Array class?
            // TODO: and do we really need to use Array class?

            ControlState.EvaluationStack.PopValue(out CilValueInt32 numElems);

            var newArr = new CilArray(instruction.TypeSpec.GetCilType(_program), numElems.Value, _program);
            var arrRef = ManagedMemory.Store(newArr);

            ControlState.EvaluationStack.PushValue(arrRef);

            ControlState.MoveToNextInstruction();
        }

        public override void VisitStoreArrayElementInstruction(StoreArrayElementInstruction instruction)
        {
            ControlState.EvaluationStack.PopValue(_program, instruction.TypeSpec.GetCilType(_program), out var value);
            ControlState.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = ManagedMemory.Load(arrayRef) as CilArray;
            array.SetValue(value, indexVal, ManagedMemory);

            ControlState.MoveToNextInstruction();
        }

        public override void VisitUnboxAnyInstruction(UnboxAnyInstruction instruction)
        {
            ControlState.EvaluationStack.PopValue(out CilValueReference objRef);

            var obj = ManagedMemory.Load(objRef);
            var type = instruction.TypeSpec.GetCilType(_program);
            var value = type.Unbox(obj, ManagedMemory, _program);

            ControlState.EvaluationStack.PushValue(value);
            ControlState.MoveToNextInstruction();
        }
    }
}