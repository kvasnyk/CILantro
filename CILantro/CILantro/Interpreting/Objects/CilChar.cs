using CILantro.Interpreting.Types;
using CILantro.Interpreting.Values;

namespace CILantro.Interpreting.Objects
{
    public class CilChar : CilValueType
    {
        public CilValueChar Value { get; }

        public CilChar(CilValueChar value)
        {
            Value = value;
        }

        public override object AsRuntime(CilType type)
        {
            return Value.Value;
        }
    }
}