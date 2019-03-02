using CILantro.Structure;

namespace CILantro.Interpreting.State
{
    public class CilCallStackItem
    {
        public CilMethod Method { get; set; }

        public CilMethodState MethodState { get; set; }
    }
}