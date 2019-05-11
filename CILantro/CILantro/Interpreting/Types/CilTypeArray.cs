using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeArray : CilType
    {
        public CilType ElementType { get; }

        public override bool IsValueType => throw new NotImplementedException();

        public override bool IsNullable => throw new NotImplementedException();

        public CilTypeArray(CilType elementType)
        {
            ElementType = elementType;
        }

        public override Type GetRuntimeType()
        {
            var fakeArray = Array.CreateInstance(ElementType.GetRuntimeType(), 0);
            return fakeArray.GetType();
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueReference);
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var cilArray = new CilArray(obj as Array, ElementType, program);
            var arrayRef = managedMemory.Store(cilArray);
            return arrayRef;
        }
    }
}