namespace CILantro.Interpreting.Objects
{
    public class CilUInt8Value : CilValue
    {
        public byte Value { get; set; }

        public CilUInt8Value(byte value)
        {
            Value = value;
        }

        public override object GetValue()
        {
            return Value;
        }
    }
}