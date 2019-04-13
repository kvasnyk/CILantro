using CILantro.Instructions.None;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.State;
using CILantro.Visitors;
using System;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionNoneInterpreterVisitor : InstructionNoneVisitor
    {
        private readonly CilControlState _state;

        private readonly CilHeap _heap;

        public InstructionNoneInterpreterVisitor(CilControlState state, CilHeap heap)
        {
            _state = state;
            _heap = heap;
        }

        protected override void VisitAddInstruction(AddInstruction instruction)
        {
            var value2 = _state.CurrentEvaluationStack.Pop() as CilInt32Value;
            var value1 = _state.CurrentEvaluationStack.Pop() as CilInt32Value;

            var result = new CilInt32Value(value1.Value + value2.Value);

            _state.CurrentEvaluationStack.Push(result);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitDuplicateInstruction(DuplicateInstruction instruction)
        {
            var obj = _state.CurrentEvaluationStack.Peek();
            var objDuplicate = obj.Duplicate();

            _state.CurrentEvaluationStack.Push(objDuplicate);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadArrayElementRefInstruction(LoadArrayElementRefInstruction instruction)
        {
            var index = _state.CurrentEvaluationStack.Pop() as CilInt32Value;

            var arrayRef = _state.CurrentEvaluationStack.Pop() as CilReference;
            var array = _heap.Load(arrayRef.Address) as Array;

            var elem = array.GetValue(index.Value);

            var elemRef = _heap.Store(elem);
            var result = new CilReference(elemRef);

            _state.CurrentEvaluationStack.Push(result);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadConstI40Intruction(LoadConstI40Instruction instruction)
        {
            var intValue = new CilInt32Value(0);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadConstI41Instruction(LoadConstI41Instruction instruction)
        {
            var intValue = new CilInt32Value(1);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadConstI42Instruction(LoadConstI42Instruction instruction)
        {
            var intValue = new CilInt32Value(2);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadConstI43Instruction(LoadConstI43Instruction instruction)
        {
            var intValue = new CilInt32Value(3);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadConstI44Instruction(LoadConstI44Instruction instruction)
        {
            var intValue = new CilInt32Value(4);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadConstI45Instruction(LoadConstI45Instruction instruction)
        {
            var intValue = new CilInt32Value(5);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadConstI46Instruction(LoadConstI46Instruction instruction)
        {
            var intValue = new CilInt32Value(6);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadConstI47Instruction(LoadConstI47Instruction instruction)
        {
            var intValue = new CilInt32Value(7);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadConstI48Instruction(LoadConstI48Instruction instruction)
        {
            var intValue = new CilInt32Value(8);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadConstI4M1Instruction(LoadConstI4M1Instruction instruction)
        {
            var intValue = new CilInt32Value(-1);
            _state.CurrentEvaluationStack.Push(intValue);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadLocal0Instruction(LoadLocal0Instruction instruction)
        {
            var value = _state.CurrentLocals.Load(0);

            _state.CurrentEvaluationStack.Push(value);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitLoadLocal1Instruction(LoadLocal1Instruction instruction)
        {
            var value = _state.CurrentLocals.Load(1);

            _state.CurrentEvaluationStack.Push(value);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitReturnInstruction(ReturnInstruction instruction)
        {
            _state.CurrentMethodState.Instruction = null;
        }

        protected override void VisitStoreArrayElementI2Instruction(StoreArrayElementI2Instruction instruction)
        {
            var value = _state.CurrentEvaluationStack.Pop() as CilInt16Value;
            var index = _state.CurrentEvaluationStack.Pop() as CilInt32Value;
            var arrayRef = _state.CurrentEvaluationStack.Pop() as CilReference;
            var array = _heap.Load(arrayRef.Address) as Array;
            var arrayElem = Convert.ChangeType(value.Value, array.GetType().GetElementType());
            array.SetValue(arrayElem, index.Value);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitStoreLocal0Instruction(StoreLocal0Instruction instruction)
        {
            var value = _state.CurrentEvaluationStack.Pop();

            _state.CurrentLocals.Store(0, value);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        protected override void VisitStoreLocal1Instruction(StoreLocal1Instruction instruction)
        {
            var value = _state.CurrentEvaluationStack.Pop();

            _state.CurrentLocals.Store(1, value);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }
    }
}