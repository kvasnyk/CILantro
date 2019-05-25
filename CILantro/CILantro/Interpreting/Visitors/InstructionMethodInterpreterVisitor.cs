using CILantro.Instructions;
using CILantro.Instructions.Method;
using CILantro.Interpreting.Instances;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.State;
using CILantro.Interpreting.Types;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using CILantro.Utils;
using CILantro.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

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
            var callExternal = _program.IsExternalType(instruction.TypeSpec);

            var methodArgs = PopMethodArgs(instruction);
            IValue thisVal = null;
            if (instruction.CallConv.IsInstance)
                _state.EvaluationStack.PopValue(_program, instruction.TypeSpec.GetCilType(_program), out thisVal);

            if (callExternal)
            {
                var result = CallExternalMethod(instruction, thisVal, methodArgs.ToArray(), null);

                if (!(instruction.ReturnType is CilTypeVoid))
                {
                    var resultVal = instruction.ReturnType.CreateValueFromRuntime(result, _managedMemory, _program);
                    _state.EvaluationStack.PushValue(resultVal);
                }

                _state.MoveToNextInstruction();
            }
            else
            {
                var @class = _program.Classes.Single(c => c.Name.ToString() == instruction.TypeSpec.ClassName.ToString());
                var method = @class.Methods.Single(m => m.Name == instruction.MethodName && AreArgumentsAssignable(instruction.SigArgs, m.Arguments));

                var sigArgsWithThis = CompleteSigArgs(instruction, method);
                var argsWithThis = CompleteArgs(instruction, methodArgs, thisVal);

                var newMethodState = new CilMethodState(method, sigArgsWithThis, argsWithThis, _program);

                _state.MoveToNextInstruction();
                _state.CallStack.Push(newMethodState);
            }
        }

        public override void VisitCallVirtualInstruction(CallVirtualInstruction instruction)
        {
            if (!instruction.CallConv.IsInstance)
                throw new System.NotImplementedException();

            var methodArgs = PopMethodArgs(instruction);
            _state.EvaluationStack.PopValue(_program, instruction.TypeSpec.GetCilType(_program), out var thisVal);

            var callExternal = true;

            CilClassInstance thisClassInstance = null;
            CilObject thisObject = null;

            if (thisVal is CilValueReference thisValRef)
            {
                var thisObj = _managedMemory.Load(thisValRef);

                if (thisObj is CilClassInstance)
                {
                    thisClassInstance = thisObj as CilClassInstance;
                }
                else
                {
                    thisObject = thisObj;
                    callExternal = true;
                }
            }
            else
                throw new System.NotImplementedException();

            CilMethod method = null;

            if (thisClassInstance != null)
            {
                var currentClass = thisClassInstance.Class;
                while (true)
                {
                    var possibleMethod = currentClass.Methods.SingleOrDefault(m => m.Name == instruction.MethodName && AreArgumentsAssignable(instruction.SigArgs, m.Arguments));
                    if (possibleMethod != null)
                    {
                        method = possibleMethod;
                        callExternal = false;
                        break;
                    }

                    currentClass = currentClass.Extends;
                    if (currentClass == null)
                    {
                        callExternal = true;
                        break;
                    }
                }
            }

            if (callExternal)
            {
                var result = CallExternalMethod(instruction, thisVal, methodArgs.ToArray(), null);

                if (!(instruction.ReturnType is CilTypeVoid))
                {
                    var resultVal = instruction.ReturnType.CreateValueFromRuntime(result, _managedMemory, _program);
                    _state.EvaluationStack.PushValue(resultVal);
                }

                _state.MoveToNextInstruction();
            }
            else
            {
                var sigArgsWithThis = CompleteSigArgs(instruction, method);
                var argsWithThis = CompleteArgs(instruction, methodArgs, thisVal);

                var newMethodState = new CilMethodState(method, sigArgsWithThis, argsWithThis, _program);

                _state.MoveToNextInstruction();
                _state.CallStack.Push(newMethodState);
            }
        }

        public override void VisitNewObjectInstruction(NewObjectInstruction instruction)
        {
            var callExternal = _program.IsExternalType(instruction.TypeSpec);

            var methodArgs = PopMethodArgs(instruction);

            if (callExternal)
            {
                object thisObject = null;
                if (instruction.CallConv.IsInstance)
                    thisObject = GetRuntimeEmptyInstance(instruction, methodArgs, true);

                var result = CallExternalMethod(instruction, null, methodArgs.ToArray(), thisObject);
                var resultVal = instruction.TypeSpec.GetCilType(_program).CreateValueFromRuntime(result, _managedMemory, _program);

                _state.EvaluationStack.PushValue(resultVal);
                _state.MoveToNextInstruction();
            }
            else
            {
                var @class = _program.Classes.Single(c => c.Name.ToString() == instruction.TypeSpec.ClassName.ToString());
                var method = @class.Methods.Single(m => m.Name == instruction.MethodName && AreArgumentsAssignable(instruction.SigArgs, m.Arguments));

                var emptyInstance = new CilClassInstance(@class, _program, _managedMemory);
                var thisRef = _managedMemory.Store(emptyInstance);
                _state.EvaluationStack.PushValue(thisRef);

                var sigArgsWithThis = CompleteSigArgs(instruction, method);
                var argsWithThis = CompleteArgs(instruction, methodArgs, thisRef);

                var newMethodState = new CilMethodState(method, sigArgsWithThis, argsWithThis, _program);

                _state.MoveToNextInstruction();
                _state.CallStack.Push(newMethodState);
            }
        }

        private object CallExternalMethod(CilInstructionMethod instruction, IValue instanceVal, IValue[] argsVal, object instanceObj)
        {
            var instance = instanceObj != null ?
                instanceObj :
                instruction.CallConv.IsInstance ?
                    instanceVal.AsRuntime(instruction.TypeSpec.GetCilType(_program), _managedMemory, _program) :
                    null;
            var args = argsVal.Zip(instruction.SigArgs, (argVal, sigArg) => argVal.AsRuntime(sigArg.Type, _managedMemory, _program)).ToArray();

            var callerConfig = new ExternalMethodCallerConfig
            {
                AssemblyName = instruction.TypeSpec.ClassName?.AssemblyName,
                ClassName = instruction.TypeSpec.ClassName?.ClassName,
                ExternalType = instruction.TypeSpec.ClassName == null ? instruction.TypeSpec.GetCilType(_program).GetRuntimeType(_program) : null,
                MethodName = instruction.MethodName,
                Arguments = args,
                Types = instruction.SigArgs.Select(sa => sa.Type.GetRuntimeType(_program)).ToArray(),
                Instance = instance,
                CallConstructor = instruction.MethodName == ".ctor",
                IsInstanceCall = instruction.CallConv.IsInstance
            };

            var result = ExternalMetodCaller.Call(callerConfig);
            return result;
        }

        private object GetRuntimeThis(CilClassInstance classInstance, CilType type)
        {
            return classInstance?.AsRuntime(type, _managedMemory, _program);
        }

        private object GetRuntimeEmptyInstance(CilInstructionMethod instruction, List<IValue> methodArgs, bool isNewObject)    
        {
            object emptyInstance = null;
           
            if (instruction.TypeSpec.Type != null && instruction.TypeSpec.Type is CilTypeArray cilTypeArray)
            {
                if (isNewObject)
                {
                    var lengths = methodArgs.Cast<CilValueInt32>().Select(v => v.Value + 1).ToArray();
                    emptyInstance = Array.CreateInstance(cilTypeArray.ElementType.GetRuntimeType(_program), lengths);
                }
                else
                    throw new System.NotImplementedException();
            }
            else
            {
                var type = ReflectionHelper.GetExternalType(instruction.TypeSpec.ClassName);
                emptyInstance = FormatterServices.GetUninitializedObject(@type);
            }

            return emptyInstance;
        }

        private void StoreExternalResult(object result, CilType returnType, bool isNewObjectInstruction)
        {
            if (!(returnType is CilTypeVoid) || isNewObjectInstruction)
            {
                var value = returnType.CreateValueFromRuntime(result, _managedMemory, _program);
                _state.EvaluationStack.PushValue(value);
            }
        }

        private List<IValue> PopMethodArgs(CilInstructionMethod instruction)
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

        private List<CilSigArg> CompleteSigArgs(CilInstructionMethod instruction, CilMethod method)
        {
            var isInstanceCall = instruction.CallConv.IsInstance;

            var instanceSigArg = new CilSigArg
            {
                Id = ".this",
                Type = instruction.TypeSpec.GetCilType(_program)
            };

            var result = isInstanceCall ?
                (new List<CilSigArg> { instanceSigArg }).Concat(instruction.SigArgs).ToList() :
                instruction.SigArgs;

            var start = isInstanceCall ? 1 : 0;
            for (int i = start; i < result.Count; i++)
            {
                result[i].Id = isInstanceCall ? method.Arguments[i - 1].Id : method.Arguments[i].Id;
            }

            return result;
        }

        private List<IValue> CompleteArgs(CilInstructionMethod instruction, List<IValue> args, IValue instanceVal)
        {
            var isInstanceCall = instruction.CallConv.IsInstance;

            var result = isInstanceCall ?
                (new List<IValue> { instanceVal }).Concat(args).ToList() :
                args;

            return result;
        }
    }
}