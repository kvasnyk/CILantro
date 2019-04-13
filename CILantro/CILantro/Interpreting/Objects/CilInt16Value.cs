namespace CILantro.Interpreting.Objects
{
    public class CilInt16Value : CilValue
    {
        public short Value { get; }

        public CilInt16Value(short value)
        {
            Value = value;
        }

        public override object GetValue()
        {
            return Value;
        }
    }
}