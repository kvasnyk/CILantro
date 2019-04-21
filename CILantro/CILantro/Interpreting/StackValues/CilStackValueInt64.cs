namespace CILantro.Interpreting.StackValues
{
    public struct CilStackValueInt64 : IStackValue
    {
        public long Value { get; }

        public ulong ValueUnsigned => (ulong)Value;

        public CilStackValueInt64(long value)
        {
            Value = value;
        }
    }
}