using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;
using System.Linq;

namespace CILantro.Interpreting.Types
{
    public class CilTypeArray : CilType
    {
        public CilType ElementType { get; }

        public int Dimensions { get; }

        public override bool IsValueType(CilProgram program)
        {
            throw new NotImplementedException();
        }

        public override bool IsNullable => throw new NotImplementedException();

        public CilTypeArray(CilType elementType, int dims = 1)
        {
            ElementType = elementType;
            Dimensions = dims;
        }

        public override Type GetRuntimeType(CilProgram program)
        {
            var lengths = Enumerable.Repeat(0, Dimensions).ToArray();
            var fakeArray = Array.CreateInstance(ElementType.GetRuntimeType(program), lengths);
            var result = fakeArray.GetType();
            return result;
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueReference);
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var runtimeArr = obj as Array;
            if (Dimensions == 1)
            {
                var resultArray = new IValue[runtimeArr.Length];
                for (int i = 0; i < runtimeArr.Length; i++)
                {
                    resultArray[i] = ElementType.CreateValueFromRuntime(runtimeArr.GetValue(i), managedMemory, program);
                }

                var cilArray = new CilArray(resultArray, ElementType);
                var arrayRef = managedMemory.Store(cilArray);
                return arrayRef;
            }

            var extObj = new CilObjectExternal(obj);
            var objRef = managedMemory.Store(extObj);
            return objRef;
        }

        public override IValue CreateDefaultValue(CilProgram program)
        {
            return new CilValueNull();
        }

        public override bool IsAssignableFrom(CilType other)
        {
            if (other is CilTypeArray otherArray)
                return ElementType.IsAssignableFrom(otherArray.ElementType);

            return false;
        }

        public override IValue Unbox(CilObject obj, CilManagedMemory managedMemory, CilProgram program)
        {
            throw new NotImplementedException();
        }
    }
}