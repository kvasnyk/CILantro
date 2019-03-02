using System;
using System.Collections.Generic;

namespace CILantro.Interpreting.Memory
{
    public class CilDictionaryHeap : CilHeap
    {
        private readonly Dictionary<int, object> _dictionary;

        private int _nextAddress = 0;

        public CilDictionaryHeap()
        {
            _dictionary = new Dictionary<int, object>();
        }

        public override void Delete(int address)
        {
            throw new NotImplementedException();
        }

        public override object Load(int address)
        {
            return _dictionary[address];
        }

        public override int Store(object obj)
        {
            var address = _nextAddress;
            _dictionary[address] = obj;
            _nextAddress++;
            return address;
        }
    }
}