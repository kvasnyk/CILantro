namespace CILantro.Interpreting.Objects
{
    public class CilReference : CilObject
    {
        public int Address { get; }

        public CilReference(int address)
        {
            Address = address;
        }
    }
}