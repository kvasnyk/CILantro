using CILantro.Interpreting.Memory;

namespace CILantro.Interpreting.State
{
    public class CilExecutionState
    {
        public CilControlState ControlState { get; }

        public CilManagedMemory ManagedMemory { get; }

        public CilExecutionState(CilControlState controlState, CilManagedMemory managedMemory)
        {
            ControlState = controlState;
            ManagedMemory = managedMemory;
        }
    }
}