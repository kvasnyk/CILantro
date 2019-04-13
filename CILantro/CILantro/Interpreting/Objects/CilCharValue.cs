namespace CILantro.Interpreting.Objects
{
    public class CilCharValue : CilValue
    {
        public char Value { get; }

        public CilCharValue(char value)
        {
            Value = value;
        }

        public override object GetValue()
        {
            return Value;
        }

        public override CilObject Duplicate()
        {
            return new CilCharValue(Value);
        }
    }
}