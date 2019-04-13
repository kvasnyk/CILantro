namespace CILantro.Interpreting.Objects
{
    public class CilInt32Value : CilValue
    {
        public int Value { get; }

        public CilInt32Value(int value)
        {
            Value = value;
        }

        public override object GetValue()
        {
            return Value;
        }

        public override CilObject Duplicate()
        {
            return new CilInt32Value(Value);
        }
    }
}