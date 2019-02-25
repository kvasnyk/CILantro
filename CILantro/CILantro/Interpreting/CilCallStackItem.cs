using CILantro.Structure;

namespace CILantro.Interpreting
{
    public class CilCallStackItem
    {
        public CilMethod Method { get; set; }

        public CilMethodState MethodState { get; set; }
    }
}