using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Values
{
    public struct CilValueFloat64 : IValue
    {
        public double Value { get; }

        public CilValueFloat64(double value)
        {
            Value = value;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory)
        {
            if (cilType is CilTypeFloat64)
                return Value;

            throw new System.NotImplementedException();
        }
    }
}