using CILantro.Structure;
using System;
using System.Reflection;

namespace CILantro.Utils
{
    public static class ReflectionHelper
    {
        public static Type GetExternalType(CilTypeSpec typeSpec, CilProgram program)
        {
            if (typeSpec.ClassName != null)
                return GetExternalType(typeSpec.ClassName);

            return typeSpec.Type.GetRuntimeType(program);
        }

        public static Type GetExternalType(CilClassName className)
        {
            var dllName = $"Externals/{className.AssemblyName}.dll";
            var assembly = Assembly.LoadFrom(dllName);
            var type = assembly.GetType(className.ClassName);
            return type;
        }

        public static Type GetExternalType(string assemblyName, string className)
        {
            var cilClassName = new CilClassName
            {
                AssemblyName = assemblyName,
                ClassName = className
            };

            return GetExternalType(cilClassName);
        }
    }
}