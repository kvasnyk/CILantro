namespace CILantro.Interpreting.Objects
{
    public class CilUInt16Value : CilValue
    {
        public ushort Value { get; }

        public CilUInt16Value(ushort value)
        {
            Value = value;
        }

        public override object GetValue()
        {
            return Value;
        }
    }
}