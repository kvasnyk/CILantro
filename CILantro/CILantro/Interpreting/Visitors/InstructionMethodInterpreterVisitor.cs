using CILantro.Instructions;
using CILantro.Instructions.Method;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackValues;
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

                _state.MoveToNextInstruction();
            }
            else
            {
                var @class = _program.Classes.Single(c => c.Name.ToString() == instruction.TypeSpec.ClassName.ToString());
                var @method = @class.Methods.Single(m => m.Name == instruction.MethodName);
                var methodArgs = PopMethodArguments(instruction);
                var methodState = new CilMethodState(@method, @method.Arguments, methodArgs);

                _state.MoveToNextInstruction();
                _state.CallStack.Push(methodState);
            }
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

        public override void VisitNewObjectInstruction(NewObjectInstruction instruction)
        {
            // TODO: finish implementation
            // TODO: handle non-external types

            var isExternalType = _program.IsExternalType(instruction.TypeSpec);

            if (isExternalType)
            {
                var result = CallExternalMethod(instruction);
                StoreExternalResult(result, instruction.TypeSpec.GetCilType());
            }
            else
            {
                var @class = _program.Classes.Single(c => c.Name.ToString() == instruction.TypeSpec.ClassName.ToString());
                var @method = @class.Methods.Single(m => m.Name == instruction.MethodName);
                var methodState = new CilMethodState(@method, new List<CilSigArg>(), new List<IValue>());

                _state.MoveToNextInstruction();
                _state.CallStack.Push(methodState);
            }

            _state.MoveToNextInstruction();
        }

        private object CallExternalMethod(CilInstructionMethod instruction)
        {
            var args = PopExternalMethodArguments(instruction);

            object instance = null;
            if (instruction.CallConv.IsInstance && instruction.MethodName != ".ctor")
            {
                _state.EvaluationStack.Pop(out var stackVal);

                if (stackVal is CilStackValueReference stackValReference)
                {
                    var instanceRef = new CilValueReference(stackValReference.Address);
                    instance = _managedMemory.Load(instanceRef).AsRuntime(instruction.TypeSpec.GetCilType());
                }
                else if (stackVal is CilStackValuePointer stackValPointer)
                {
                    var instancePointer = new CilValueManagedPointer(stackValPointer.ValueToRef);
                    instance = instancePointer.ValueToRef.AsRuntime(instruction.TypeSpec.GetCilType(), _managedMemory);
                }
                else
                    throw new System.NotImplementedException();
            }
            
            var callerConfig = new ExternalMethodCallerConfig
            {
                AssemblyName = instruction.TypeSpec.ClassName.AssemblyName,
                ClassName = instruction.TypeSpec.ClassName.ClassName,
                MethodName = instruction.MethodName,
                Arguments = args,
                Types = instruction.SigArgs.Select(sa => sa.Type.GetRuntimeType()).ToArray(),
                Instance = instance,
                CallConstructor = instruction.MethodName == ".ctor"
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

        private List<IValue> PopMethodArguments(CilInstructionMethod instruction)
        {
            var methodArgs = new List<IValue>();
            for (int i = 0; i < instruction.SigArgs.Count; i++)
            {
                var ind = instruction.SigArgs.Count - i - 1;
                _state.EvaluationStack.PopValue(_program, instruction.SigArgs[ind].Type, out var value);
                methodArgs.Add(value);
            }
            methodArgs.Reverse();
            return methodArgs;
        }

        private object[] PopExternalMethodArguments(CilInstructionMethod instruction)
        {
            var methodArguments = new List<object>();
            for (int i = 0; i < instruction.SigArgs.Count; i++)
            {
                var ind = instruction.SigArgs.Count - i - 1;
                _state.EvaluationStack.PopValue(_program, instruction.SigArgs[ind].Type, out var value);
                var argument = value.AsRuntime(instruction.SigArgs[ind].Type, _managedMemory);
                methodArguments.Add(argument);
            }
            methodArguments.Reverse();
            return methodArguments.ToArray();
        }
    }
}