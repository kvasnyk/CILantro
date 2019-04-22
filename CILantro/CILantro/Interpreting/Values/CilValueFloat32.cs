using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Values
{
    public struct CilValueFloat32 : IValue
    {
        public float Value { get; }

        public CilValueFloat32(float value)
        {
            Value = value;
        }

        public object AsRuntime(CilType cilType, CilManagedMemory managedMemory)
        {
            if (cilType is CilTypeFloat32)
                return Value;

            throw new System.NotImplementedException();
        }

        public CilValueType Box()
        {
            throw new System.NotImplementedException();
        }
    }
}