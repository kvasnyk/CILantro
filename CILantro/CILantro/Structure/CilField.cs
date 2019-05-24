using CILantro.Interpreting.Types;
using CILantro.Interpreting.Values;

namespace CILantro.Structure
{
    public class CilField
    {
        public string Name { get; set; }

        public CilType Type { get; set; }

        public bool IsStatic { get; set; }

        public IValue InitValue { get; set; }
    }
}