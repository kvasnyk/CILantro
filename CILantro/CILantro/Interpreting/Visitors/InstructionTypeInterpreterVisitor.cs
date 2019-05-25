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
        private readonly CilControlState _state;

        private readonly CilManagedMemory _managedMemory;

        private readonly CilProgram _program;

        public InstructionTypeInterpreterVisitor(CilProgram program, CilControlState state, CilManagedMemory managedMemory)
        {
            _state = state;
            _managedMemory = managedMemory;
            _program = program;
        }

        public override void VisitBoxInstruction(BoxInstruction instruction)
        {
            var cilType = instruction.TypeSpec.GetCilType(_program);
            _state.EvaluationStack.PopValue(_program, cilType, out var val);

            CilObject obj = null;
            if (cilType.IsValueType(_program) && !cilType.IsNullable)
            {
                obj = val.Box();
            }

            var objRef = _managedMemory.Store(obj);
            _state.EvaluationStack.PushValue(objRef);

            _state.MoveToNextInstruction();
        }

        public override void VisitInitObjectInstruction(InitObjectInstruction instruction)
        {
            _state.EvaluationStack.PopValue(out CilValueManagedPointer pointer);

            var type = instruction.TypeSpec.GetCilType(_program);
            var empty = type.CreateDefaultValue(_program);
            pointer.ValueToRef = empty;

            _state.MoveToNextInstruction();
        }

        public override void VisitIsInstanceInstruction(IsInstanceInstruction instruction)
        {
            _state.EvaluationStack.PopValue(out CilValueReference objRef);
            var obj = _managedMemory.Load(objRef);

            if (obj is CilClassInstance objClassInstance)
            {
                if (objClassInstance.IsInstanceOf(instruction.TypeSpec, _program))
                    _state.EvaluationStack.PushValue(objRef);
                else
                    _state.EvaluationStack.PushValue(new CilValueNull());
            }
            else
            {
                throw new System.NotImplementedException();
            }

            _state.MoveToNextInstruction();
        }

        public override void VisitLoadArrayElementInstruction(LoadArrayElementInstruction instruction)
        {
            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, instruction.TypeSpec.GetCilType(_program), _managedMemory, _program);

            _state.EvaluationStack.PushValue(elem);
            _state.MoveToNextInstruction();
        }

        public override void VisitNewArrayInstruction(NewArrayInstruction instruction)
        {
            // TODO: finish implementation
            // TODO: can we really use Array class?
            // TODO: and do we really need to use Array class?

            _state.EvaluationStack.PopValue(out CilValueInt32 numElems);

            var newArr = new CilArray(instruction.TypeSpec.GetCilType(_program), numElems.Value, _program);
            var arrRef = _managedMemory.Store(newArr);

            _state.EvaluationStack.PushValue(arrRef);

            _state.MoveToNextInstruction();
        }

        public override void VisitStoreArrayElementInstruction(StoreArrayElementInstruction instruction)
        {
            _state.EvaluationStack.PopValue(_program, instruction.TypeSpec.GetCilType(_program), out var value);
            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            array.SetValue(value, indexVal, _managedMemory);

            _state.MoveToNextInstruction();
        }

        public override void VisitUnboxAnyInstruction(UnboxAnyInstruction instruction)
        {
            _state.EvaluationStack.PopValue(out CilValueReference objRef);

            var obj = _managedMemory.Load(objRef);
            var type = instruction.TypeSpec.GetCilType(_program);
            var value = type.Unbox(obj, _managedMemory, _program);

            _state.EvaluationStack.PushValue(value);
            _state.MoveToNextInstruction();
        }
    }
}