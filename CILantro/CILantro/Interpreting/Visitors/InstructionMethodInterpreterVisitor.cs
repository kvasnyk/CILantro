using CILantro.Instructions;
using CILantro.Instructions.Method;
using CILantro.Interpreting.Instances;
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
                var @method = @class.Methods.Single(m => m.Name == instruction.MethodName && AreArgumentsAssignable(m.Arguments, instruction.SigArgs));
                var sigArgs = BuildSigArgs(_program, instruction, @method, @method.CallConv.IsInstance);
                var methodArgs = PopMethodArguments(instruction, sigArgs, @method.CallConv.IsInstance, @method.CallConv.IsInstance);
                var methodState = new CilMethodState(@method, sigArgs, methodArgs);

                _state.MoveToNextInstruction();
                _state.CallStack.Push(methodState);
            }
        }

        public override void VisitCallVirtualInstruction(CallVirtualInstruction instruction)
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
                var baseMethod = @class.Methods.Single(m => m.Name == instruction.MethodName && AreArgumentsAssignable(m.Arguments, instruction.SigArgs));
                var sigArgs = BuildSigArgs(_program, instruction, baseMethod, baseMethod.CallConv.IsInstance);
                var methodArgs = PopMethodArguments(instruction, sigArgs, baseMethod.CallConv.IsInstance, baseMethod.CallConv.IsInstance);

                var thisRef = _managedMemory.Load(methodArgs[0] as CilValueReference) as CilClassInstance;
                var lookingClass = thisRef.Class;
                CilMethod method = null;
                while (true)
                {
                    method = lookingClass.Methods.SingleOrDefault(m => m.Name == instruction.MethodName && AreArgumentsAssignable(m.Arguments, instruction.SigArgs));

                    if (method != null)
                        break;

                    lookingClass = lookingClass.Extends;
                }

                var methodState = new CilMethodState(method, sigArgs, methodArgs);

                _state.MoveToNextInstruction();
                _state.CallStack.Push(methodState);
            }
        }

        public override void VisitNewObjectInstruction(NewObjectInstruction instruction)
        {
            // TODO: finish implementation
            // TODO: handle non-external types

            var isExternalType = _program.IsExternalType(instruction.TypeSpec);

            if (isExternalType)
            {
                var result = CallExternalMethod(instruction);
                StoreExternalResult(result, instruction.TypeSpec.GetCilType(_program));

                _state.MoveToNextInstruction();
            }
            else
            {
                var @class = _program.Classes.Single(c => c.Name.ToString() == instruction.TypeSpec.ClassName.ToString());
                var @method = @class.Methods.Single(m => m.Name == instruction.MethodName && AreArgumentsAssignable(m.Arguments, instruction.SigArgs));

                var emptyInstance = new CilClassInstance(@class, _program);
                var reference = _managedMemory.Store(emptyInstance);

                var sigArgs = BuildSigArgs(_program, instruction, @method, @method.CallConv.IsInstance);
                var instanceSigArgValues = (new List<IValue> { reference }).Concat(PopMethodArguments(instruction, sigArgs, @method.CallConv.IsInstance, false)).ToList();
                var methodState = new CilMethodState(@method, sigArgs, instanceSigArgValues);

                _state.MoveToNextInstruction();
                _state.CallStack.Push(methodState);
            }
        }

        private object CallExternalMethod(CilInstructionMethod instruction)
        {
            var args = PopExternalMethodArguments(instruction);

            object instance = null;
            if (instruction.CallConv.IsInstance)
            {
                _state.EvaluationStack.Pop(out var stackVal);

                if (stackVal is CilStackValueReference stackValReference)
                {
                    var instanceRef = new CilValueReference(stackValReference.Address);
                    instance = _managedMemory.Load(instanceRef).AsRuntime(instruction.TypeSpec.GetCilType(_program), _managedMemory);
                }
                else if (stackVal is CilStackValuePointer stackValPointer)
                {
                    var instancePointer = new CilValueManagedPointer(stackValPointer.ValueToRef);
                    instance = instancePointer.ValueToRef.AsRuntime(instruction.TypeSpec.GetCilType(_program), _managedMemory);
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
                CallConstructor = instruction.MethodName == ".ctor",
                IsInstanceCall = instruction.CallConv.IsInstance
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

        private List<IValue> PopMethodArguments(CilInstructionMethod instruction, List<CilSigArg> sigArgs, bool isInstanceCall, bool getThisRef)
        {
            var startIndex = !isInstanceCall || (isInstanceCall && getThisRef) ? 0 : 1;

            var methodArgs = new List<IValue>();
            for (int i = startIndex; i < sigArgs.Count; i++)
            {
                var ind = sigArgs.Count - i - 1;
                ind += startIndex;

                _state.EvaluationStack.PopValue(_program, sigArgs[ind].Type, out var value);
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

        private bool AreArgumentsAssignable(List<CilSigArg> args1, List<CilSigArg> args2)
        {
            if (args1.Count != args2.Count)
                return false;

            for (int i = 0; i < args1.Count; i++)
            {
                if (!args1[i].IsAssignableFrom(args2[i]))
                    return false;
            }

            return true;
        }

        private List<CilSigArg> BuildSigArgs(CilProgram program, CilInstructionMethod instruction, CilMethod method, bool isInstanceCall)
        {
            var instanceSigArg = new CilSigArg
            {
                Id = ".this",
                Type = instruction.TypeSpec.GetCilType(_program)
            };
            var instanceSigArgs = (new List<CilSigArg> { instanceSigArg }).Concat(method.Arguments).ToList();
            return isInstanceCall ?
                (new List<CilSigArg> { instanceSigArg }).Concat(method.Arguments).ToList() :
                method.Arguments;
        }
    }
}