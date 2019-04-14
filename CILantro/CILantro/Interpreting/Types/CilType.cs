using System;

namespace CILantro.Interpreting.Types
{
    public abstract class CilType
    {
        public abstract Type GetRuntimeType();
    }
}