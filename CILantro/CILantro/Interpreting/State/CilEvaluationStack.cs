using CILantro.Interpreting.StackValues;
using CILantro.Interpreting.Types;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;
using System.Collections.Generic;

namespace CILantro.Interpreting.State
{
    public class CilEvaluationStack
    {
        private readonly Stack<IStackValue> _stack;

        public CilEvaluationStack()
        {
            _stack = new Stack<IStackValue>();
        }

        public void Push(IStackValue val)
        {
            _stack.Push(val);
        }

        public void PushValue(IValue val)
        {
            var stackVal = ConvertToStackValue(val);
            _stack.Push(stackVal);
        }

        public IStackValue Pop()
        {
            return _stack.Pop();
        }

        public void Pop(out IStackValue val)
        {
            val = Pop();
        }

        public void Pop(out IStackValue val1, out IStackValue val2)
        {
            Pop(out val2);
            Pop(out val1);
        }

        public void PopValue<T>(out T val)
            where T : struct, IValue
        {
            Pop(out var stackVal);
            val = (T)ConvertToValue(stackVal, typeof(T));
        }

        public void PopValue<T1, T2>(out T1 val1, out T2 val2)
            where T1 : struct, IValue
            where T2 : struct, IValue
        {
            PopValue(out val2);
            PopValue(out val1);
        }

        public void PopValue<T1, T2, T3>(out T1 val1, out T2 val2, out T3 val3)
            where T1 : struct, IValue
            where T2 : struct, IValue
            where T3 : struct, IValue
        {
            PopValue(out val3);
            PopValue(out val2);
            PopValue(out val1);
        }

        public void PopValue(CilProgram program, CilType cilType, out IValue val)
        {
            Pop(out var stackVal);
            var valType = cilType.GetValueType(program);
            val = ConvertToValue(stackVal, valType);
        }

        private IStackValue ConvertToStackValue(IValue val)
        {
            if (val is CilValueInt8 valInt8)
                return new CilStackValueInt32(valInt8.Value);

            if (val is CilValueInt16 valInt16)
                return new CilStackValueInt32(valInt16.Value);

            if (val is CilValueInt32 valInt32)
                return new CilStackValueInt32(valInt32.Value);

            if (val is CilValueInt64 valInt64)
                return new CilStackValueInt64(valInt64.Value);

            if (val is CilValueUInt8 valUint8)
                return new CilStackValueInt32(valUint8.Value);

            if (val is CilValueUInt16 valUint16)
                return new CilStackValueInt32(valUint16.Value);

            if (val is CilValueUInt32 valUint32)
                return new CilStackValueInt32((int)valUint32.Value);

            if (val is CilValueUInt64 valUint64)
                return new CilStackValueInt64((long)valUint64.Value);

            if (val is CilValueChar valChar)
                return new CilStackValueInt32(valChar.Value);

            if (val is CilValueFloat32 valFloat32)
                return new CilStackValueFloat(valFloat32.Value);

            if (val is CilValueFloat64 valFloat64)
                return new CilStackValueFloat(valFloat64.Value);

            if (val is CilValueReference valReference)
                return new CilStackValueReference(valReference.Address);

            if (val is CilValueExternal valExternal)
                return new CilStackValueExternal(valExternal.Value);

            if (val is CilValueBool valBool)
                return new CilStackValueInt32(valBool.Value ? 1 : 0);

            throw new NotImplementedException();
        }

        private IValue ConvertToValue(IStackValue stackVal, Type valType)
        {
            if (valType == typeof(CilValueInt8))
            {
                if (stackVal is CilStackValueInt32 stackValInt32)
                    return new CilValueInt8((sbyte)stackValInt32.Value);
            }

            if (valType == typeof(CilValueInt16))
            {
                if (stackVal is CilStackValueInt32 stackValInt32)
                    return new CilValueInt16((short)stackValInt32.Value);
            }

            if (valType == typeof(CilValueInt32))
            {
                if (stackVal is CilStackValueInt32 stackValInt32)
                    return new CilValueInt32(stackValInt32.Value);
            }

            if (valType == typeof(CilValueInt64))
            {
                if (stackVal is CilStackValueInt64 stackValInt64)
                    return new CilValueInt64(stackValInt64.Value);
            }

            if (valType == typeof(CilValueUInt8))
            {
                if (stackVal is CilStackValueInt32 stackValInt32)
                    return new CilValueUInt8((byte)stackValInt32.Value);
            }

            if (valType == typeof(CilValueUInt16))
            {
                if (stackVal is CilStackValueInt32 stackValInt32)
                    return new CilValueUInt16((ushort)stackValInt32.Value);
            }

            if (valType == typeof(CilValueUInt32))
            {
                if (stackVal is CilStackValueInt32 stackValInt32)
                    return new CilValueUInt32((uint)stackValInt32.Value);
            }

            if (valType == typeof(CilValueUInt64))
            {
                if (stackVal is CilStackValueInt64 stackValInt64)
                    return new CilValueUInt64((ulong)stackValInt64.Value);
            }

            if (valType == typeof(CilValueChar))
            {
                if (stackVal is CilStackValueInt32 stackValInt32)
                    return new CilValueChar((char)stackValInt32.Value);
            }

            if (valType == typeof(CilValueFloat32))
            {
                if (stackVal is CilStackValueFloat stackValFloat)
                    return new CilValueFloat32((float)stackValFloat.Value);
            }

            if (valType == typeof(CilValueFloat64))
            {
                if (stackVal is CilStackValueFloat stackValFloat)
                    return new CilValueFloat64(stackValFloat.Value);
            }

            if (valType == typeof(CilValueReference))
            {
                if (stackVal is CilStackValueReference stackValReference)
                    return new CilValueReference(stackValReference.Address);
            }

            if (valType == typeof(CilValueExternal))
            {
                if (stackVal is CilStackValueExternal stackValExternal)
                    return new CilValueExternal(stackValExternal.ExternalValue);
            }

            if (valType == typeof(CilValueBool))
            {
                if (stackVal is CilStackValueInt32 stackValInt32)
                    return new CilValueBool(stackValInt32.Value != 0);
            }

            throw new NotImplementedException();
        }
    }
}