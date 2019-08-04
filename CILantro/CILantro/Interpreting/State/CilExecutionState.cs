using CILantro.Interpreting.Memory;

namespace CILantro.Interpreting.State
{
    public class CilExecutionState
    {
        public CilControlState ControlState { get; set; }

        public CilManagedMemory ManagedMemory { get; set; }
    }
}