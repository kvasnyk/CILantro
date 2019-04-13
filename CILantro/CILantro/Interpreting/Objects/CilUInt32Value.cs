namespace CILantro.Interpreting.Objects
{
    public class CilUInt32Value : CilValue
    {
        public uint Value { get; }

        public CilUInt32Value(uint value)
        {
            Value = value;
        }

        public override object GetValue()
        {
            return Value;
        }
    }
}