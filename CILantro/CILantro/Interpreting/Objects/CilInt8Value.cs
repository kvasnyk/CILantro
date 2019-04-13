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

        public override CilObject Duplicate()
        {
            return new CilInt8Value(Value);
        }
    }
}