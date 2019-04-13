using CILantro.Instructions;
using CILantro.Instructions.Method;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.State;
using CILantro.Structure;
using CILantro.Utils;
using CILantro.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionMethodInterpreterVisitor : InstructionMethodVisitor
    {
        private readonly CilControlState _state;

        private readonly CilHeap _heap;

        public InstructionMethodInterpreterVisitor(CilControlState state, CilHeap heap)
        {
            _state = state;
            _heap = heap;
        }

        public override void VisitCallInstruction(CallInstruction instruction)
        {
            var callConfig = BuildCallerConfigBase(instruction);

            var result = MethodCaller.Call(callConfig);
            StoreResult(result, instruction);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        public override void VisitCallVirtualInstruction(CallVirtualInstruction instruction)
        {
            var callConfig = BuildCallerConfigBase(instruction);

            var result = MethodCaller.Call(callConfig);
            StoreResult(result, instruction);

            _state.CurrentMethodState.Instruction = _state.CurrentMethodInfo.GetNextInstruction(instruction);
        }

        private void StoreResult(object result, CilInstructionMethod instruction)
        {
            if (!(instruction.ReturnType is CilTypeVoid))
            {
                CilObject obj = null;

                if (instruction.ReturnType is CilTypeSimple simpleType)
                {
                    obj = simpleType.BuildValue(result);
                }
                else if (instruction.ReturnType is CilTypeString stringType)
                {
                    var resultAddress = _heap.Store(result);
                    obj = new CilReference(resultAddress);
                }
                else if (instruction.ReturnType is CilTypeValue valueType)
                {
                    obj = new CilValueTypeValue(result);
                }
                else if (instruction.ReturnType is CilTypeArray arrayType)
                {
                    var resultAddress = _heap.Store(result);
                    obj = new CilReference(resultAddress);
                }
                else
                {
                    throw new NotImplementedException();
                }

                _state.CurrentEvaluationStack.Push(obj);
            }
        }

        private object[] PopMethodArguments(CilInstructionMethod instruction)
        {
            var methodArguments = new List<object>();
            for (int i = 0; i < instruction.SigArgs.Count; i++)
            {
                var argument = _state.CurrentEvaluationStack.Pop();

                var methodArgument = argument is CilReference referenceArgument ?
                    _heap.Load(referenceArgument.Address) :
                    (argument as CilValue).GetValue();

                methodArguments.Add(methodArgument);
            }
            methodArguments.Reverse();
            return methodArguments.ToArray();
        }

        private MethodCallerConfig BuildCallerConfigBase(CilInstructionMethod instruction)
        {
            var methodArguments = PopMethodArguments(instruction);

            var objRef = instruction.CallConv.IsInstance ? _state.CurrentEvaluationStack.Pop() as CilReference : null;

            object obj = null;
            if (objRef != null)
                obj = _heap.Load(objRef.Address);

            return new MethodCallerConfig
            {
                AssemblyName = instruction.TypeSpec.ClassName.AssemblyName,
                ClassName = instruction.TypeSpec.ClassName.ClassName,
                MethodName = instruction.MethodName,
                Arguments = methodArguments,
                Types = instruction.SigArgs.Select(sa => sa.Type.GetRuntimeType()).ToArray(),
                Instance = obj
            };
        }
    }
}