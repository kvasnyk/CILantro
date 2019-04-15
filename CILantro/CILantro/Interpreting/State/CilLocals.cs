using CILantro.Interpreting.StackObjects;
using CILantro.Structure;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace CILantro.Interpreting.State
{
    public class CilLocals
    {
        private OrderedDictionary _dict;

        public CilLocals(List<CilSigArg> localsSigArgs)
        {
            _dict = new OrderedDictionary(localsSigArgs.Count);

            foreach (var sigArg in localsSigArgs)
            {
                _dict.Add(sigArg.Id, null);
            }
        }

        public void Store(string id, IStackObject value)
        {
            _dict[id] = value;
        }

        public void Store(short index, IStackObject value)
        {
            _dict[index] = value;
        }

        public IStackObject Load(short index)
        {
            return _dict[index] as IStackObject;
        }

        public IStackObject Load(string id)
        {
            return _dict[id] as IStackObject;
        }
    }
}