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

        public IStackObject Sub(IStackObject value2)
        {
            throw new System.NotImplementedException();
        }

        public IStackObject Convert(CilType type)
        {
            if (type is CilTypeBool)
                return new CilValueBool(Value);

            throw new System.NotImplementedException();
        }

        public IStackObject Mul(IStackObject value2)
        {
            throw new System.NotImplementedException();
        }

        public IStackObject Div(IStackObject value2)
        {
            throw new System.NotImplementedException();
        }

        public IStackObject Mod(IStackObject value2)
        {
            throw new System.NotImplementedException();
        }
    }
}