using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeFloat32 : CilType
    {
        public override Type GetRuntimeType()
        {
            return typeof(float);
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueFloat32);
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var value = new CilValueFloat32((float)obj);
            return value;
        }
    }
}