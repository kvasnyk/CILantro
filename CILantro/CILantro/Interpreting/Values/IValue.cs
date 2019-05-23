using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;
using CILantro.Structure;

namespace CILantro.Interpreting.Values
{
    public interface IValue
    {
        object AsRuntime(CilType cilType, CilManagedMemory managedMemory, CilProgram program);

        CilValueType Box();

        ref object GetRef();

        int GetPointerValue();

        IValue As(CilType cilType);
    }
}