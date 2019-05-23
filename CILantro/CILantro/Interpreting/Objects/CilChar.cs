using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;
using CILantro.Interpreting.Values;
using CILantro.Structure;

namespace CILantro.Interpreting.Objects
{
    public class CilChar : CilValueType
    {
        public CilValueChar Value { get; }

        public CilChar(CilValueChar value)
        {
            Value = value;
        }

        public override object AsRuntime(CilType type, CilManagedMemory managedMemory, CilProgram program)
        {
            return Value.Value;
        }
    }
}