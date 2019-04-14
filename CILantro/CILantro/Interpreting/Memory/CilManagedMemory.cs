using CILantro.Interpreting.Objects;
using CILantro.Interpreting.StackObjects;

namespace CILantro.Interpreting.Memory
{
    public abstract class CilManagedMemory
    {
        public abstract CilReference Store(CilObject obj);

        public abstract CilObject Load(CilReference reference);

        public abstract void Delete(CilReference reference);
    }
}