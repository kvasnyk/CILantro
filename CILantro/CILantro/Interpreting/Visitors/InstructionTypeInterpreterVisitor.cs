using CILantro.Instructions.Type;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.State;
using CILantro.Visitors;
using System;
using System.Reflection;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionTypeInterpreterVisitor : InstructionTypeVisitor
    {
        private readonly CilControlState _state;

        private readonly CilHeap _heap;

        public InstructionTypeInterpreterVisitor(CilControlState state, CilHeap heap)
        {
            _state = state;
            _heap = heap;
        }

        public override void VisitNewArrayInstruction(NewArrayInstruction instruction)
        {
            var numElems = _state.CurrentEvaluationStack.Pop() as CilInt32Value;

            var assembly = Assembly.Load(instruction.TypeSpec.ClassName.AssemblyName);
            var type = assembly.GetType(instruction.TypeSpec.ClassName.ClassName);

            var array = Array.CreateInstance(type, numElems.Value);

            var arrAddress = _heap.Store(array);
            var arrRef = new CilReference(arrAddress);

            _state.CurrentEvaluationStack.Push(arrRef);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }
    }
}