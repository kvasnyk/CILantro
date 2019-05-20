﻿using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;
using System.Linq;

namespace CILantro.Interpreting.Objects
{
    public class CilArray : CilObject
    {
        private IValue[] _array;

        private CilType _type;

        public int Length => _array.Length;

        public CilArray(IValue[] array, CilType type)
        {
            _array = array;
            _type = type;
        }

        public CilArray(CilType type, int numElems)
        {
            _array = new IValue[numElems];
            _type = type;
        }

        public override object AsRuntime(CilType type, CilManagedMemory managedMemory)
        {
            if (type is CilTypeArray cilTypeArray)
            {
                var result = Array.CreateInstance(cilTypeArray.ElementType.GetRuntimeType(), Length);
                var objectArr = _array.Select(elem => elem.AsRuntime(cilTypeArray.ElementType, managedMemory)).ToArray();
                Array.Copy(objectArr, result, Length);
                return result;
            }

            throw new System.NotImplementedException();
        }

        public void SetValue(IValue value, CilValueInt32 indexVal, CilManagedMemory managedMemory)
        {
            _array[indexVal.Value] = value;
        }

        public IValue GetValue(CilValueInt32 indexVal, CilType desiredType, CilManagedMemory managedMemory, CilProgram program)
        {
            return _array[indexVal.Value].As(desiredType ?? _type);
        }
    }
}