using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;
using CILantro.Structure;

namespace CILantro.Interpreting.Objects
{
    public abstract class CilObject
    {
        public abstract object AsRuntime(CilType type, CilManagedMemory managedMemory, CilProgram program);
    }
}