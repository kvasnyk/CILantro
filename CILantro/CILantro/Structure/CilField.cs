using CILantro.AbstractSyntaxTree.Other;
using CILantro.Interpreting.Types;
using CILantro.Interpreting.Values;
using System.Reflection;

namespace CILantro.Structure
{
    public class CilField
    {
        public string Name { get; set; }

        public CilType Type { get; set; }

        public bool IsStatic => Attributes.HasFlag(CilFieldAttributes.Static);

        public IValue InitValue { get; set; }

        public string AtId { get; set; }

        public CilFieldAttributes Attributes { get; set; }

        public FieldAttributes GetRuntimeAttributes()
        {
            var result = default(FieldAttributes);
            if (IsStatic)
                result |= FieldAttributes.Static;
            return result;
        }
    }
}