using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Values;

namespace CILantro.Interpreting.Memory
{
    public abstract class CilManagedMemory
    {
        public abstract CilValueReference Store(CilObject obj);

        public abstract CilObject Load(CilValueReference reference);

        public abstract void Delete(CilValueReference reference);
    }
}