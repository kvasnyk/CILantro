using CILantro.Interpreting.Types;

namespace CILantro.Structure
{
    public class CilSigArg
    {
        public CilType Type { get; set; }

        public string Id { get; set; }

        public bool IsAssignableFrom(CilSigArg other)
        {
            return Type.IsAssignableFrom(other.Type);
        }
    }
}