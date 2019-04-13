namespace CILantro.Interpreting.Objects
{
    public class CilReference : CilObject
    {
        public int Address { get; }

        public CilReference(int address)
        {
            Address = address;
        }

        public override CilObject Duplicate()
        {
            return new CilReference(Address);
        }
    }
}