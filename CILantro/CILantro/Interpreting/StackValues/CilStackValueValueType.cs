using CILantro.Interpreting.Instances;

namespace CILantro.Interpreting.StackValues
{
    public class CilStackValueValueType : IStackValue
    {
        public CilClassInstance Value { get; }

        public CilStackValueValueType(CilClassInstance value)
        {
            Value = value;
        }
    }
}