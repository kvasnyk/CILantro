namespace CILantro.Interpreting.Objects
{
    public class CilUInt64Value : CilValue
    {
        public ulong Value { get; set; }

        public CilUInt64Value(ulong value)
        {
            Value = value;
        }

        public override object GetValue()
        {
            return Value;
        }
    }
}