namespace CILantro.Interpreting.StackValues
{
    public struct CilStackValueInt32 : IStackValue
    {
        public int Value { get; set; }

        public uint ValueUnsigned => (uint)Value;

        public CilStackValueInt32(int value)
        {
            Value = value;
        }
    }
}