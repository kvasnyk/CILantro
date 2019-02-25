using CILantro.Interpreting;

namespace CILantro.Instructions
{
    public abstract class CilInstruction
    {
        public abstract override string ToString();

        public abstract void Execute(CilControlState state);
    }
}