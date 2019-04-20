namespace CILantro.Interpreting.StackValues
{
    public struct CilStackValueExternal : IStackValue
    {
        public object ExternalValue { get; }

        public CilStackValueExternal(object externalValue)
        {
            ExternalValue = externalValue;
        }
    }
}