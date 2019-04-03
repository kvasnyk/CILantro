namespace CILantro.Interpreting.Objects
{
    public class CilInt32Value : CilObject
    {
        public int Value { get; }

        public CilInt32Value(int value)
        {
            Value = value;
        }
    }
}