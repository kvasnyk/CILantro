using CILantro.Structure;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace CILantro.Utils
{
    public static class RuntimeTypeBuilder
    {
        private static int _counter = 0;

        public static Type RegisterType(CilClassName parentClassName)
        {
            var assemblyName = new AssemblyName("CILantroProxiesAssembly");
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndCollect);

            var moduleBuilder = assemblyBuilder.DefineDynamicModule("CILantroProxiesModule");

            var parentTypeAssembly = Assembly.Load(parentClassName.AssemblyName);
            var parentType = parentTypeAssembly.GetType(parentClassName.ClassName);

            var typeName = $"{parentClassName.ClassName}_CILantroProxy_{_counter}";
            var typeBuilder = moduleBuilder.DefineType(typeName, TypeAttributes.Class, parentType);

            foreach (var method in parentType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (method.IsAbstract)
                {
                    var methodBuilder = typeBuilder.DefineMethod(method.Name, (method.Attributes & (~MethodAttributes.Abstract)), method.ReturnType, method.GetParameters().Select(p => p.ParameterType).ToArray());
                    var msil = methodBuilder.GetILGenerator();
                    msil.ThrowException(typeof(NotImplementedException));
                    typeBuilder.DefineMethodOverride(methodBuilder, method);
                }
            }

            var type = typeBuilder.CreateType();

            _counter++;

            return type;
        }
    }
}