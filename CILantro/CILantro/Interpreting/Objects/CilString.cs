using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Objects
{
    public class CilString : CilObject
    {
        private readonly string _value;

        public CilString(string value)
        {
            _value = value;
        }

        public override object AsRuntime(CilType type, CilManagedMemory managedMemory)
        {
            return _value;
        }
    }
}