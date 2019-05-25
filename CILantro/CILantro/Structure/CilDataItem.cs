using CILantro.Interpreting.Values;

namespace CILantro.Structure
{
    public class CilDataItem
    {
        public byte[] ByteArray { get; set; }

        public IValue GetValue()
        {
            var result = new CilValueExternal(ByteArray);
            return result;
        }
    }
}