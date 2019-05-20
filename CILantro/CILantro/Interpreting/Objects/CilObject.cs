using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Objects
{
    public abstract class CilObject
    {
        public abstract object AsRuntime(CilType type, CilManagedMemory managedMemory);
    }
}