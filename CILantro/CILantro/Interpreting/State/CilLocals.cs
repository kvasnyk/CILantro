using CILantro.Interpreting.StackObjects;

namespace CILantro.Interpreting.State
{
    public class CilLocals
    {
        private IStackObject[] _array;

        public CilLocals()
        {
            _array = new IStackObject[2];
        }

        public void Store(short index, IStackObject value)
        {
            _array[index] = value;
        }

        public IStackObject Load(short index)
        {
            return _array[index];
        }
    }
}
