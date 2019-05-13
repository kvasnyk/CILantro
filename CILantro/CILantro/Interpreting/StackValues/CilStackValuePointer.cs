using CILantro.Interpreting.Values;

namespace CILantro.Interpreting.StackValues
{
    public struct CilStackValuePointer : IStackValue
    {
        public IValue ValueToRef { get; set; }

        public CilStackValuePointer(IValue valueToRef)
        {
            ValueToRef = valueToRef;
        }
    }
}