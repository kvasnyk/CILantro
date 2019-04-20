namespace CILantro.Interpreting.StackValues
{
    public struct CilStackValueInt64 : IStackValue
    {
        public long Value { get; }

        public CilStackValueInt64(long value)
        {
            Value = value;
        }
    }
}