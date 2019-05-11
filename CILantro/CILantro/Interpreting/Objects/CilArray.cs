using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Objects
{
    public class CilArray : CilObject
    {
        private Array _array;

        private CilType _type;

        public CilArray(Array array, CilType type)
        {
            _array = array;
            _type = type;
        }

        public CilArray(CilType type, int numElems)
        {
            _array = Array.CreateInstance(type.GetRuntimeType(), numElems);
            _type = type;
        }

        public override object AsRuntime(CilType type)
        {
            return _array;
        }

        public void SetValue(IValue value, CilValueInt32 indexVal, CilManagedMemory managedMemory)
        {
            var arrayElem = value.AsRuntime(_type, managedMemory);
            _array.SetValue(arrayElem, indexVal.Value);
        }

        public IValue GetValue(CilValueInt32 indexVal, CilType desiredType, CilManagedMemory managedMemory, CilProgram program)
        {
            var resultType = desiredType ?? _type;
            var arrayElem = _array.GetValue(indexVal.Value);

            return resultType.CreateValueFromRuntime(arrayElem, managedMemory, program);
        }
    }
}