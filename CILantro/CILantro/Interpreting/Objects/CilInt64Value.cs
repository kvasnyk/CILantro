namespace CILantro.Interpreting.Objects
{
    public class CilInt64Value : CilValue
    {
        public long Value { get; }

        public CilInt64Value(long value)
        {
            Value = value;
        }

        public override object GetValue()
        {
            return Value;
        }

        public override CilObject Duplicate()
        {
            return new CilInt64Value(Value);
        }
    }
}