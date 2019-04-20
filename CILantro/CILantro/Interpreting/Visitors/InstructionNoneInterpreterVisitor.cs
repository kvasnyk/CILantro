using CILantro.Instructions.None;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.StackValues;
using CILantro.Interpreting.State;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using CILantro.Visitors;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionNoneInterpreterVisitor : InstructionNoneVisitor
    {
        private readonly CilControlState _state;

        private readonly CilManagedMemory _managedMemory;

        private readonly CilProgram _program;

        public InstructionNoneInterpreterVisitor(CilProgram program, CilControlState state, CilManagedMemory managedMemory)
        {
            _state = state;
            _managedMemory = managedMemory;
            _program = program;
        }

        protected override void VisitAddInstruction(AddInstruction instruction)
        {
            // TODO: finish implementation

            //_state.EvaluationStack.Pop(out var value1, out var value2);
            //var result = value1.Add(value2);
            //_state.EvaluationStack.Push(result);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitConvertI1Instruction(ConvertI1Instruction instruction)
        {
            // TODO: finish implementation

            //_state.EvaluationStack.Pop(out var value);
            //var result = value.Convert(new CilTypeInt8());
            //_state.EvaluationStack.Push(result);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitConvertI2Instruction(ConvertI2Instruction instruction)
        {
            // TODO: finish implementation

            //_state.EvaluationStack.Pop(out var value);
            //var result = value.Convert(new CilTypeInt16());
            //_state.EvaluationStack.Push(result);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitConvertI8Instruction(ConvertI8Instruction instruction)
        {
            // TODO: finish implementation

            //_state.EvaluationStack.Pop(out var value);
            //var result = value.Convert(new CilTypeInt64());
            //_state.EvaluationStack.Push(result);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitConvertR4Instruction(ConvertR4Instruction instruction)
        {
            // TODO: finish implementation

            //_state.EvaluationStack.Pop(out var value);
            //var result = value.Convert(new CilTypeFloat32());
            //_state.EvaluationStack.Push(result);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitConvertR8Instruction(ConvertR8Instruction instruction)
        {
            // TODO: finish implementation

            //_state.EvaluationStack.Pop(out var value);
            //var result = value.Convert(new CilTypeFloat64());
            //_state.EvaluationStack.Push(result);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitConvertRUnsignedInstruction(ConvertRUnsignedInstruction instruction)
        {
            // TODO: finish implementation

            //_state.EvaluationStack.Pop(out var value);
            //var result = value.Convert(new CilTypeFloat64());
            //_state.EvaluationStack.Push(result);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitConvertU1Instruction(ConvertU1Instruction instruction)
        {
            // TODO: finish implementation

            //_state.EvaluationStack.Pop(out var value);
            //var result = value.Convert(new CilTypeUInt8());
            //_state.EvaluationStack.Push(result);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitConvertU2Instruction(ConvertU2Instruction instruction)
        {
            // TODO: finish implementation

            //_state.EvaluationStack.Pop(out var value);
            //var result = value.Convert(new CilTypeUInt16());
            //_state.EvaluationStack.Push(result);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitConvertU8Instruction(ConvertU8Instruction instruction)
        {
            // TODO: finish implementation

            //_state.EvaluationStack.Pop(out var value);
            //var result = value.Convert(new CilTypeUInt64());
            //_state.EvaluationStack.Push(result);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitDivideInstruction(DivideInstruction instruction)
        {
            // TODO: finish implementation

            //_state.EvaluationStack.Pop(out var value1, out var value2);
            //var result = value1.Div(value2);
            //_state.EvaluationStack.Push(result);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitDivideUnsignedInstruction(DivideUnsignedInstruction instruction)
        {
            // TODO: finish implementation

            //_state.EvaluationStack.Pop(out var value1, out var value2);
            //var result = value1.Div(value2);
            //_state.EvaluationStack.Push(result);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitDuplicateInstruction(DuplicateInstruction instruction)
        {
            _state.EvaluationStack.Pop(out var value);

            _state.EvaluationStack.Push(value);
            _state.EvaluationStack.Push(value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementRefInstruction(LoadArrayElementRefInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, _managedMemory);

            _state.EvaluationStack.PushValue(elem);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI40Intruction(LoadConstI40Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(0);
            _state.EvaluationStack.Push(stackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI41Instruction(LoadConstI41Instruction instruction)
        {
            var stackVal = new CilStackValueInt32(1);
            _state.EvaluationStack.Push(stackVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI42Instruction(LoadConstI42Instruction instruction)
        {
            // TODO: finish implementation

            //var value = new CilValueInt32(2);
            //_state.EvaluationStack.Push(value);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitLoadConstI43Instruction(LoadConstI43Instruction instruction)
        {
            // TODO: finish implementation

            //var value = new CilValueInt32(3);
            //_state.EvaluationStack.Push(value);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitLoadConstI44Instruction(LoadConstI44Instruction instruction)
        {
            // TODO: finish implementation

            //var value = new CilValueInt32(4);
            //_state.EvaluationStack.Push(value);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitLoadConstI45Instruction(LoadConstI45Instruction instruction)
        {
            // TODO: finish implementation

            //var value = new CilValueInt32(5);
            //_state.EvaluationStack.Push(value);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitLoadConstI46Instruction(LoadConstI46Instruction instruction)
        {
            // TODO: finish implementation

            //var value = new CilValueInt32(6);
            //_state.EvaluationStack.Push(value);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitLoadConstI47Instruction(LoadConstI47Instruction instruction)
        {
            // TODO: finish implementation

            //var value = new CilValueInt32(7);
            //_state.EvaluationStack.Push(value);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitLoadConstI48Instruction(LoadConstI48Instruction instruction)
        {
            // TODO: finish implementation

            //var value = new CilValueInt32(8);
            //_state.EvaluationStack.Push(value);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitLoadConstI4M1Instruction(LoadConstI4M1Instruction instruction)
        {
            // TODO: finish implementation

            //var value = new CilValueInt32(-1);
            //_state.EvaluationStack.Push(value);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitLoadLocal0Instruction(LoadLocal0Instruction instruction)
        {
            // TODO: finish implementation

            //var value = _state.Locals.Load(0);
            //_state.EvaluationStack.Push(value);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitLoadLocal1Instruction(LoadLocal1Instruction instruction)
        {
            // TODO: finish implementation

            //var value = _state.Locals.Load(1);
            //_state.EvaluationStack.Push(value);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitLoadLocal2Instruction(LoadLocal2Instruction instruction)
        {
            // TODO: finish implementation

            //var value = _state.Locals.Load(2);
            //_state.EvaluationStack.Push(value);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitLoadLocal3Instruction(LoadLocal3Instruction instruction)
        {
            // TODO: finish implementation

            //var value = _state.Locals.Load(3);
            //_state.EvaluationStack.Push(value);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitMultiplyInstruction(MultiplyInstruction instruction)
        {
            // TODO: finish implementation

            //_state.EvaluationStack.Pop(out var value1, out var value2);
            //var result = value1.Mul(value2);
            //_state.EvaluationStack.Push(result);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitRemainderInstruction(RemainderInstruction instruction)
        {
            // TODO: finish implementation

            //_state.EvaluationStack.Pop(out var value1, out var value2);
            //var result = value1.Mod(value2);
            //_state.EvaluationStack.Push(result);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitRemainderUnsignedInstruction(RemainderUnsignedInstruction instruction)
        {
            // TODO: finish implementation

            //_state.EvaluationStack.Pop(out var value1, out var value2);
            //var result = value1.Mod(value2);
            //_state.EvaluationStack.Push(result);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }

        protected override void VisitReturnInstruction(ReturnInstruction instruction)
        {
            // TODO: finish implementation

            //_state.MethodState.Instruction = null;
            throw new System.NotImplementedException();
        }

        protected override void VisitStoreArrayElementI2Instruction(StoreArrayElementI2Instruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.PopValue(out CilValueReference arrayRef, out CilValueInt32 indexVal, out CilValueInt16 valueVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            array.SetValue(valueVal, indexVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreLocal0Instruction(StoreLocal0Instruction instruction)
        {
            var localType = _state.Locals.GetLocalType(null, 0);
            _state.EvaluationStack.PopValue(_program, localType, out var value);
            _state.Locals.Store(null, 0, value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreLocal1Instruction(StoreLocal1Instruction instruction)
        {
            var localType = _state.Locals.GetLocalType(null, 1);
            _state.EvaluationStack.PopValue(_program, localType, out var value);
            _state.Locals.Store(null, 1, value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreLocal2Instruction(StoreLocal2Instruction instruction)
        {
            var localType = _state.Locals.GetLocalType(null, 2);
            _state.EvaluationStack.PopValue(_program, localType, out var value);
            _state.Locals.Store(null, 2, value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreLocal3Instruction(StoreLocal3Instruction instruction)
        {
            var localType = _state.Locals.GetLocalType(null, 3);
            _state.EvaluationStack.PopValue(_program, localType, out var value);
            _state.Locals.Store(null, 3, value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitSubtractInstruction(SubtractInstruction instruction)
        {
            // TODO: finish implementation

            //_state.EvaluationStack.Pop(out var value1, out var value2);
            //var result = value1.Sub(value2);
            //_state.EvaluationStack.Push(result);

            //_state.MoveToNextInstruction();
            throw new System.NotImplementedException();
        }
    }
}