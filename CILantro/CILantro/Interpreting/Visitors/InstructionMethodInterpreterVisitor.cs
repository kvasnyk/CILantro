using CILantro.Instructions;
using CILantro.Instructions.Method;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.State;
using CILantro.Interpreting.Types;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using CILantro.Utils;
using CILantro.Visitors;
using System.Collections.Generic;
using System.Linq;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionMethodInterpreterVisitor : InstructionMethodVisitor
    {
        private readonly CilProgram _program;

        private readonly CilControlState _state;

        private readonly CilManagedMemory _managedMemory;

        public InstructionMethodInterpreterVisitor(CilProgram program, CilControlState state, CilManagedMemory managedMemory)
        {
            _program = program;
            _state = state;
            _managedMemory = managedMemory;
        }

        public override void VisitCallInstruction(CallInstruction instruction)
        {
            // TODO: finish implementation
            // TODO: handle non-external types

            var isExternalType = _program.IsExternalType(instruction.TypeSpec);

            if (isExternalType)
            {
                var result = CallExternalMethod(instruction);
                StoreExternalResult(result, instruction.ReturnType);
            }

            _state.MoveToNextInstruction();
        }

        public override void VisitCallVirtualInstruction(CallVirtualInstruction instruction)
        {
            // TODO: finish implementation
            // TODO: handle non-external types
            // TODO: handle really virtual methods

            var isExternalType = _program.IsExternalType(instruction.TypeSpec);

            if (isExternalType)
            {
                var result = CallExternalMethod(instruction);
                StoreExternalResult(result, instruction.ReturnType);
            }

            _state.MoveToNextInstruction();
        }

        private object CallExternalMethod(CilInstructionMethod instruction)
        {
            var args = PopMethodArguments(instruction);

            object instance = null;
            if (instruction.CallConv.IsInstance)
            {
                _state.EvaluationStack.PopValue(out CilValueReference instanceRef);
                instance = _managedMemory.Load(instanceRef).AsRuntime(instruction.ReturnType);
            }
            
            var callerConfig = new ExternalMethodCallerConfig
            {
                AssemblyName = instruction.TypeSpec.ClassName.AssemblyName,
                ClassName = instruction.TypeSpec.ClassName.ClassName,
                MethodName = instruction.MethodName,
                Arguments = args,
                Types = instruction.SigArgs.Select(sa => sa.Type.GetRuntimeType()).ToArray(),
                Instance = instance
            };

            var result = ExternalMetodCaller.Call(callerConfig);
            return result;
        }

        private void StoreExternalResult(object result, CilType returnType)
        {
            if (!(returnType is CilTypeVoid))
            {
                var value = returnType.CreateValueFromRuntime(result, _managedMemory, _program);
                _state.EvaluationStack.PushValue(value);
            }
        }

        private object[] PopMethodArguments(CilInstructionMethod instruction)
        {
            var methodArguments = new List<object>();
            for (int i = 0; i < instruction.SigArgs.Count; i++)
            {
                _state.EvaluationStack.PopValue(_program, instruction.SigArgs[i].Type, out var value);
                var argument = value.AsRuntime(instruction.SigArgs[i].Type, _managedMemory);
                methodArguments.Add(argument);
            }
            methodArguments.Reverse();
            return methodArguments.ToArray();
        }

        //private MethodCallerConfig BuildCallerConfigBase(CilInstructionMethod instruction)
        //{
        //    var methodArguments = PopMethodArguments(instruction);

        //    var objRef = instruction.CallConv.IsInstance ? _state.CurrentEvaluationStack.Pop() as CilReference : null;

        //    object obj = null;
        //    if (objRef != null)
        //        obj = _heap.Load(objRef.Address);

        //    return new MethodCallerConfig
        //    {
        //        AssemblyName = instruction.TypeSpec.ClassName.AssemblyName,
        //        ClassName = instruction.TypeSpec.ClassName.ClassName,
        //        MethodName = instruction.MethodName,
        //        Arguments = methodArguments,
        //        Types = instruction.SigArgs.Select(sa => sa.Type.GetRuntimeType()).ToArray(),
        //        Instance = obj
        //    };
        //}
    }
}