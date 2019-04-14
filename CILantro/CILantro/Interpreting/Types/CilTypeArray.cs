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
    }
}