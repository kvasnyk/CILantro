using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackObjects;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;
using System.Reflection;

namespace CILantro.Interpreting.Types
{
    public class CilTypeValueType : CilType
    {
        public CilClassName ClassName { get; }

        public CilTypeValueType(CilClassName className)
        {
            ClassName = className;
        }

        public override Type GetRuntimeType()
        {
            var assembly = Assembly.Load(ClassName.AssemblyName);
            var type = assembly.GetType(ClassName.ClassName);
            return type;
        }

        public override IStackObject CreateInstanceFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            if (program.IsExternalType(ClassName))
                return new CilValueExternal(obj);

            throw new NotImplementedException();
        }
    }
}