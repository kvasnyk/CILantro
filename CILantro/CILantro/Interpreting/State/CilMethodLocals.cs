using CILantro.Interpreting.Objects;

namespace CILantro.Interpreting.State
{
    public class CilMethodLocals
    {
        private readonly CilObject[] _values;

        public CilMethodLocals()
        {
            _values = new CilObject[2];
        }

        public void Store(int index, CilObject obj)
        {
            _values[index] = obj;
        }

        public CilObject Load(int index)
        {
            return _values[index];
        }
    }
}