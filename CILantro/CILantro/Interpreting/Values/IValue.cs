using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;

namespace CILantro.Interpreting.Values
{
    public interface IValue
    {
        object AsRuntime(CilType cilType, CilManagedMemory managedMemory);

        CilValueType Box();

        ref object GetRef();
    }
}