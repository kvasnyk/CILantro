using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.StackObjects;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeString : CilType
    {
        public override IStackObject CreateInstanceFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var cilString = new CilString(obj as string);
            var stringRef = managedMemory.Store(cilString);
            return stringRef;
        }

        public override Type GetRuntimeType()
        {
            return typeof(string);
        }
    }
}