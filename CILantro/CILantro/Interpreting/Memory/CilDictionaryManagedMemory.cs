using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Values;
using System;
using System.Collections.Generic;

namespace CILantro.Interpreting.Memory
{
    public class CilDictionaryManagedMemory : CilManagedMemory
    {
        private readonly Dictionary<int, object> _dictionary;

        private int _nextAddress = 0;

        public CilDictionaryManagedMemory()
        {
            _dictionary = new Dictionary<int, object>();
        }

        public override void Delete(CilValueReference reference)
        {
            throw new NotImplementedException();
        }

        public override CilObject Load(CilValueReference reference)
        {
            return _dictionary[reference.Address] as CilObject;
        }

        public override CilValueReference Store(CilObject obj)
        {
            var address = _nextAddress;
            _dictionary[address] = obj;
            _nextAddress++;
            return new CilValueReference(address);
        }
    }
}