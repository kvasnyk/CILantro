using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;
using System;

namespace CILantro.Interpreting.Values
{
    public class CilValueNull : IValue
    {
        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory)
        {
            throw new NotImplementedException();
        }

        public CilValueType Box()
        {
            throw new NotImplementedException();
        }

        public int GetPointerValue()
        {
            throw new NotImplementedException();
        }

        public ref object GetRef()
        {
            throw new NotImplementedException();
        }
    }
}