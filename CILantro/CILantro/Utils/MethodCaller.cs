using System;
using System.Reflection;

namespace CILantro.Utils
{
    public class MethodCallerConfig
    {
        public string AssemblyName { get; set; }

        public string ClassName { get; set; }

        public string MethodName { get; set; }

        public object[] Arguments { get; set; }

        public Type[] Types { get; set; }
    }

    public static class MethodCaller
    {
        public static object Call(MethodCallerConfig config)
        {
            return CallBase(config, true);
        }

        private static object CallBase(MethodCallerConfig config, bool isVoid)
        {
            var assembly = Assembly.Load(config.AssemblyName);
            var @class = assembly.GetType(config.ClassName);
            var method = @class.GetMethod(config.MethodName, config.Types);

            var result = method.Invoke(null, config.Arguments);
            return result;
        }
    }
}