using System;
using System.Reflection;

namespace CILantro.Structure
{
    public class CilTypeSpec
    {
        public CilClassName ClassName { get; set; }

        public Type GetRuntimeType()
        {
            var assembly = Assembly.Load(ClassName.AssemblyName);
            var type = assembly.GetType(ClassName.ClassName);
            return type;
        }
    }
}