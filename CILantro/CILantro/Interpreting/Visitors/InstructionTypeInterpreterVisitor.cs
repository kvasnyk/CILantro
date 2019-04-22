﻿using CILantro.Instructions.Type;
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
            var cilType = instruction.TypeSpec.GetCilType();
            _state.EvaluationStack.PopValue(_program, cilType, out var val);

            CilObject obj = null;
            if (cilType.IsValueType && !cilType.IsNullable)
            {
                obj = val.Box();
            }

            var objRef = _managedMemory.Store(obj);
            _state.EvaluationStack.PushValue(objRef);

            _state.MoveToNextInstruction();
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