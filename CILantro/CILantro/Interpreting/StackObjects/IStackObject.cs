using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.StackObjects
{
    public interface IStackObject
    {
        T? As<T>()
            where T : struct, IStackObject;

        object AsRuntime(CilType type, CilManagedMemory managedMemory);

        IStackObject Add(IStackObject value2);

        IStackObject Convert<T>()
            where T : struct, IStackObject;
    }
}