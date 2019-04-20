using CILantro.Interpreting.Memory;
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
            throw new System.NotImplementedException();
        }
    }
}