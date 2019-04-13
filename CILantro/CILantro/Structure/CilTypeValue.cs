using System;
using System.Reflection;

namespace CILantro.Structure
{
    public class CilTypeValue : CilType
    {
        public CilClassName ClassName { get; set; }

        public override Type GetRuntimeType()
        {
            var assembly = Assembly.Load(ClassName.AssemblyName);
            var @class = assembly.GetType(ClassName.ClassName);
            return @class;
        }
    }
}