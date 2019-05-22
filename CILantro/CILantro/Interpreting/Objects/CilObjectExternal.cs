using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;
using System;

namespace CILantro.Interpreting.Objects
{
    public class CilObjectExternal : CilObject
    {
        public object ExternalObject { get; }

        public CilObjectExternal(object externalObject)
        {
            ExternalObject = externalObject;
        }

        public override object AsRuntime(CilType type, CilManagedMemory managedMemory)
        {
            if (type is CilTypeObject)
                return ExternalObject;

            throw new NotImplementedException();
        }
    }
}