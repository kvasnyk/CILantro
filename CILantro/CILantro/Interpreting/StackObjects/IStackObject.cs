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

        IStackObject Sub(IStackObject value2);

        IStackObject Mul(IStackObject value2);

        IStackObject Div(IStackObject value2);

        IStackObject Mod(IStackObject value2);

        IStackObject Convert(CilType type);
    }
}