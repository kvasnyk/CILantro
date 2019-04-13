namespace CILantro.Interpreting.Objects
{
    public class CilFloat32Value : CilValue
    {
        public float Value { get; }

        public CilFloat32Value(float value)
        {
            Value = value;
        }

        public override object GetValue()
        {
            return Value;
        }

        public override CilObject Duplicate()
        {
            return new CilFloat32Value(Value);
        }
    }
}