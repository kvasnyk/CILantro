namespace CILantro.Interpreting.StackValues
{
    public struct CilStackValueFloat : IStackValue
    {
        public double Value { get; }

        public CilStackValueFloat(double value)
        {
            Value = value;
        }
    }
}