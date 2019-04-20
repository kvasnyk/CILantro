using CILantro.Interpreting.Types;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace CILantro.Interpreting.State
{
    public class CilLocals
    {
        private OrderedDictionary _typesDict { get; }

        private OrderedDictionary _dict;

        public CilLocals(List<CilSigArg> localsSigArgs)
        {
            _dict = new OrderedDictionary(localsSigArgs.Count);
            _typesDict = new OrderedDictionary(localsSigArgs.Count);

            foreach (var sigArg in localsSigArgs)
            {
                _dict.Add(sigArg.Id, null);
                _typesDict.Add(sigArg.Id, sigArg.Type);
            }
        }

        public void Store(string id, int index, IValue value)
        {
            if (!string.IsNullOrEmpty(id))
                _dict[id] = value;
            else
                _dict[index] = value;
        }

        public IValue Load(string id, int index)
        {
            if (!string.IsNullOrEmpty(id))
                return _dict[id] as IValue;
            else
                return _dict[index] as IValue;
        }

        public CilType GetLocalType(string id, int index)
        {
            if (!string.IsNullOrEmpty(id))
                return _typesDict[id] as CilType;
            else
                return _typesDict[index] as CilType;
        }
    }
}