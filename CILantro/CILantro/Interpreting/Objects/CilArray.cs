using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;
using CILantro.Interpreting.Values;
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

        public void SetValue(IValue value, CilValueInt32 indexVal)
        {
            var arrayElem = value.AsRuntime(_type, null);
            _array.SetValue(arrayElem, indexVal.Value);
        }

        public IValue GetValue(CilValueInt32 indexVal, CilManagedMemory managedMemory, Type valueType)
        {
            var arrayElem = _array.GetValue(indexVal.Value);

            if (valueType == typeof(CilValueInt32))
            {
                if (_type is CilTypeInt32)
                {
                    return new CilValueInt32((int)arrayElem);
                }
            }
            else if (valueType == typeof(CilValueReference))
            {
                if (_type is CilTypeString)
                {
                    var cilString = new CilString(arrayElem as string);
                    var reference = managedMemory.Store(cilString);
                    return reference;
                }
            }

            throw new NotImplementedException();
        }
    }
}