namespace CILantro.Interpreting.Memory
{
    public abstract class CilHeap
    {
        public abstract int Store(object obj);

        public abstract object Load(int add);

        public abstract void Delete(int add);
    }
}