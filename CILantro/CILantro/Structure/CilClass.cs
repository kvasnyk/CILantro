using CILantro.Interpreting.Memory;
using CILantro.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CILantro.Structure
{
    public class CilClass
    {
        public CilClassName Name { get; set; }

        public CilClassName ExtendsName { get; set; }

        public CilClass Extends { get; set; }

        public List<CilMethod> Methods { get; set; }

        public List<CilField> Fields { get; set; }

        public CilMethod EntryPoint => Methods.SingleOrDefault(m => m.IsEntryPoint);

        public bool IsSequential { get; set; }

        public Type BuildRuntimeProxy(CilProgram program)
        {
            var parentClass = this;
            while (!program.IsExternalType(parentClass.ExtendsName))
                parentClass = parentClass.Extends;

            var extAssembly = Assembly.Load(parentClass.ExtendsName.AssemblyName);
            var extClass = extAssembly.GetType(parentClass.ExtendsName.ClassName);

            if (!extClass.IsAbstract)
                return extClass;

            var extProxy = RuntimeTypeBuilder.RegisterProxy(parentClass.ExtendsName);
            return extProxy;
        }

        public Type BuildRuntimeType(CilProgram program, CilManagedMemory managedMemory)
        {
            var type = RuntimeTypeBuilder.RegisterType(this, program, managedMemory);
            return type;
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}