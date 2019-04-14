using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackObjects;
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

        public void SetValue(IStackObject stackObject, CilValueInt32 indexVal)
        {
            var arrayElem = stackObject.AsRuntime(_type, null);
            _array.SetValue(arrayElem, indexVal.Value);
        }

        public IStackObject GetValue(CilValueInt32 indexVal, CilManagedMemory managedMemory)
        {
            var arrayElem = _array.GetValue(indexVal.Value);

            if (_type is CilTypeString)
            {
                var cilString = new CilString(arrayElem as string);
                var reference = managedMemory.Store(cilString);
                return reference;
            }

            throw new NotImplementedException();
        }
    }
}