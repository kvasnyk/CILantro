using CILantro.Instructions;
using CILantro.Instructions.Method;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.StackObjects;
using CILantro.Interpreting.State;
using CILantro.Interpreting.Types;
using CILantro.Interpreting.Values;
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
                _state.EvaluationStack.Pop(out CilReference instanceRef);
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
            if (returnType is CilTypeString)
            {
                var cilString = new CilString(result as string);
                var stringRef = _managedMemory.Store(cilString);
                _state.EvaluationStack.Push(stringRef);

                return;
            }
            
            if (returnType is CilTypeArray typeArray)
            {
                var cilArray = new CilArray(result as Array, typeArray.ElementType);
                var arrayRef = _managedMemory.Store(cilArray);
                _state.EvaluationStack.Push(arrayRef);

                return;
            }

            if (returnType is CilTypeInt32)
            {
                var value = new CilValueInt32((int)result);
                _state.EvaluationStack.Push(value);

                return;
            }

            if (returnType is CilTypeVoid)
            {
                return;
            }

            throw new NotImplementedException();
        }

        private object[] PopMethodArguments(CilInstructionMethod instruction)
        {
            var methodArguments = new List<object>();
            for (int i = 0; i < instruction.SigArgs.Count; i++)
            {
                var argument = _state.EvaluationStack.Pop().AsRuntime(instruction.SigArgs[i].Type, _managedMemory);
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