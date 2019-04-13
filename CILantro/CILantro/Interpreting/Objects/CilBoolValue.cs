namespace CILantro.Interpreting.Objects
{
    public class CilBoolValue : CilValue
    {
        public bool Value { get; }

        public CilBoolValue(bool value)
        {
            Value = value;
        }

        public override object GetValue()
        {
            return Value;
        }

        public override CilObject Duplicate()
        {
            return new CilBoolValue(Value);
        }
    }
}