namespace CILantro.Interpreting.StackValues
{
    public struct CilStackValueReference : IStackValue
    {
        public int? Address { get; }

        public CilStackValueReference(int? address)
        {
            Address = address;
        }
    }
}