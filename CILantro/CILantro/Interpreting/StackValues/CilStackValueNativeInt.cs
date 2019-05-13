namespace CILantro.Interpreting.StackValues
{
    public struct CilStackValueNativeInt : IStackValue
    {
        public int Value { get; set; }

        public CilStackValueNativeInt(int value)
        {
            Value = value;
        }
    }
}