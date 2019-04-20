namespace CILantro.Interpreting.StackValues
{
    public struct CilStackValueInt32 : IStackValue
    {
        public int Value { get; set; }

        public CilStackValueInt32(int value)
        {
            Value = value;
        }
    }
}