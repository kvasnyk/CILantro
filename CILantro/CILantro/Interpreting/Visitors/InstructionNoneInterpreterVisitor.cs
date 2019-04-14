using CILantro.Instructions.None;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.StackObjects;
using CILantro.Interpreting.State;
using CILantro.Interpreting.Values;
using CILantro.Visitors;
using System;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionNoneInterpreterVisitor : InstructionNoneVisitor
    {
        private readonly CilControlState _state;

        private readonly CilManagedMemory _managedMemory;

        public InstructionNoneInterpreterVisitor(CilControlState state, CilManagedMemory managedMemory)
        {
            _state = state;
            _managedMemory = managedMemory;
        }

        protected override void VisitAddInstruction(AddInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out CilValueInt32 value1, out CilValueInt32 value2);

            var result = new CilValueInt32(value1.Value + value2.Value);

            _state.EvaluationStack.Push(result);

            _state.MoveToNextInstruction();
        }

        protected override void VisitDuplicateInstruction(DuplicateInstruction instruction)
        {
            var value = _state.EvaluationStack.Pop();

            _state.EvaluationStack.Push(value);
            _state.EvaluationStack.Push(value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadArrayElementRefInstruction(LoadArrayElementRefInstruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out CilReference arrayRef, out CilValueInt32 indexVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            var elem = array.GetValue(indexVal, _managedMemory);

            _state.EvaluationStack.Push(elem);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI40Intruction(LoadConstI40Instruction instruction)
        {
            // TODO: finish implementation

            var value = new CilValueInt32(0);
            _state.EvaluationStack.Push(value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI41Instruction(LoadConstI41Instruction instruction)
        {
            // TODO: finish implementation

            var value = new CilValueInt32(1);
            _state.EvaluationStack.Push(value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadConstI42Instruction(LoadConstI42Instruction instruction)
        {
            // TODO: correct implementation

            //var intValue = new CilInt32Value(2);
            //_state.CurrentEvaluationStack.Push(intValue);

            //_state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);

            throw new NotImplementedException();
        }

        protected override void VisitLoadConstI43Instruction(LoadConstI43Instruction instruction)
        {
            // TODO: correct implementation

            //var intValue = new CilInt32Value(3);
            //_state.CurrentEvaluationStack.Push(intValue);

            //_state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);

            throw new NotImplementedException();
        }

        protected override void VisitLoadConstI44Instruction(LoadConstI44Instruction instruction)
        {
            // TODO: correct implementation

            //var intValue = new CilInt32Value(4);
            //_state.CurrentEvaluationStack.Push(intValue);

            //_state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);

            throw new NotImplementedException();
        }

        protected override void VisitLoadConstI45Instruction(LoadConstI45Instruction instruction)
        {
            // TODO: correct implementation

            //var intValue = new CilInt32Value(5);
            //_state.CurrentEvaluationStack.Push(intValue);

            //_state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);

            throw new NotImplementedException();
        }

        protected override void VisitLoadConstI46Instruction(LoadConstI46Instruction instruction)
        {
            // TODO: correct implementation

            //var intValue = new CilInt32Value(6);
            //_state.CurrentEvaluationStack.Push(intValue);

            //_state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);

            throw new NotImplementedException();
        }

        protected override void VisitLoadConstI47Instruction(LoadConstI47Instruction instruction)
        {
            // TODO: correct implementation

            //var intValue = new CilInt32Value(7);
            //_state.CurrentEvaluationStack.Push(intValue);

            //_state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);

            throw new NotImplementedException();
        }

        protected override void VisitLoadConstI48Instruction(LoadConstI48Instruction instruction)
        {
            // TODO: correct implementation

            //var intValue = new CilInt32Value(8);
            //_state.CurrentEvaluationStack.Push(intValue);

            //_state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);

            throw new NotImplementedException();
        }

        protected override void VisitLoadConstI4M1Instruction(LoadConstI4M1Instruction instruction)
        {
            // TODO: correct implementation

            //var intValue = new CilInt32Value(-1);
            //_state.CurrentEvaluationStack.Push(intValue);

            //_state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);

            throw new NotImplementedException();
        }

        protected override void VisitLoadLocal0Instruction(LoadLocal0Instruction instruction)
        {
            // TODO: finish implementation

            var value = _state.Locals.Load(0);

            _state.EvaluationStack.Push(value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitLoadLocal1Instruction(LoadLocal1Instruction instruction)
        {
            // TODO: finish implementation

            var value = _state.Locals.Load(1);

            _state.EvaluationStack.Push(value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitReturnInstruction(ReturnInstruction instruction)
        {
            // TODO: finish implementation

            _state.MethodState.Instruction = null;
        }

        protected override void VisitStoreArrayElementI2Instruction(StoreArrayElementI2Instruction instruction)
        {
            // TODO: finish implementation

            _state.EvaluationStack.Pop(out CilReference arrayRef, out CilValueInt32 indexVal, out CilValueInt16 valueVal);

            var array = _managedMemory.Load(arrayRef) as CilArray;
            array.SetValue(valueVal, indexVal);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreLocal0Instruction(StoreLocal0Instruction instruction)
        {
            // TODO: finish implementation

            var value = _state.EvaluationStack.Pop();

            _state.Locals.Store(0, value);

            _state.MoveToNextInstruction();
        }

        protected override void VisitStoreLocal1Instruction(StoreLocal1Instruction instruction)
        {
            // TODO: finish implementation

            var value = _state.EvaluationStack.Pop();

            _state.Locals.Store(1, value);

            _state.MoveToNextInstruction();
        }
    }
}