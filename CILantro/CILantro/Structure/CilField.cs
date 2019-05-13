using CILantro.Interpreting.Types;

namespace CILantro.Structure
{
    public class CilField
    {
        public string Name { get; set; }

        public CilType Type { get; set; }

        public bool IsStatic { get; set; }
    }
}