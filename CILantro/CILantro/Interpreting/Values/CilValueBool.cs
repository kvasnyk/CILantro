using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Values
{
    public struct CilValueBool : IValue
    {
        public bool Value { get; }

        public CilValueBool(bool value)
        {
            Value = value;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory)
        {
            if (cilType is CilTypeBool)
                return Value;

            throw new System.NotImplementedException();
        }
    }
}