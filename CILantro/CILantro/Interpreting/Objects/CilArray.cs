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

        private CilProgram _program;

        public CilArray(Array array, CilType type, CilProgram program)
        {
            _array = array;
            _type = type;
            _program = program;
        }

        public CilArray(CilType type, int numElems, CilProgram program)
        {
            _array = Array.CreateInstance(type.GetRuntimeType(), numElems);
            _type = type;
            _program = program;
        }

        public override object AsRuntime(CilType type)
        {
            return _array;
        }

        public void SetValue(IValue value, CilValueInt32 indexVal)
        {
            var arrayElem = value.AsRuntime(_type, null);
            _array.SetValue(arrayElem, indexVal.Value);
        }

        public IValue GetValue(CilValueInt32 indexVal, CilManagedMemory managedMemory, CilType desiredType)
        {
            var resultType = desiredType ?? _type;
            var arrayElem = _array.GetValue(indexVal.Value);

            return resultType.CreateValueFromRuntime(arrayElem, managedMemory, _program);
        }
    }
}