namespace CILantro.Interpreting.Objects
{
    public class CilValueTypeValue : CilValue
    {
        public object Value { get; }

        public CilValueTypeValue(object value)
        {
            Value = value;
        }

        public override object GetValue()
        {
            return Value;
        }

        public override CilObject Duplicate()
        {
            return new CilValueTypeValue(Value);
        }
    }
}