using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackObjects;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Values
{
    public struct CilValueBool : IStackObject
    {
        public bool Value { get; }

        public CilValueBool(bool value)
        {
            Value = value;
        }

        public T? As<T>() where T : struct, IStackObject
        {
            throw new System.NotImplementedException();
        }

        public object AsRuntime(CilType type, CilManagedMemory managedMemory)
        {
            if (type is CilTypeBool)
                return Value;

            throw new System.NotImplementedException();
        }

        public IStackObject Add(IStackObject value2)
        {
            throw new System.NotImplementedException();
        }

        public IStackObject Convert<T>() where T : struct, IStackObject
        {
            throw new System.NotImplementedException();
        }
    }
}