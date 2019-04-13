namespace CILantro.Interpreting.Objects
{
    public class CilFloat64Value : CilValue
    {
        public double Value { get; }

        public CilFloat64Value(double value)
        {
            Value = value;
        }

        public override object GetValue()
        {
            return Value;
        }

        public override CilObject Duplicate()
        {
            return new CilFloat64Value(Value);
        }
    }
}