namespace CILantro.Interpreting.Objects
{
    public class CilInt8Value : CilValue
    {
        public sbyte Value { get; }

        public CilInt8Value(sbyte value)
        {
            Value = value;
        }

        public override object GetValue()
        {
            return Value;
        }
    }
}