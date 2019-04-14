using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.StackObjects;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeArray : CilType
    {
        public CilType ElementType { get; }

        public CilTypeArray(CilType elementType)
        {
            ElementType = elementType;
        }

        public override Type GetRuntimeType()
        {
            var fakeArray = Array.CreateInstance(ElementType.GetRuntimeType(), 0);
            return fakeArray.GetType();
        }

        public override IStackObject CreateInstanceFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var cilArray = new CilArray(obj as Array, ElementType);
            var arrayRef = managedMemory.Store(cilArray);
            return arrayRef;
        }
    }
}