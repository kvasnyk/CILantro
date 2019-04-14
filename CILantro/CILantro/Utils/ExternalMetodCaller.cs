using System;
using System.Reflection;

namespace CILantro.Utils
{
    public class ExternalMethodCallerConfig
    {
        public string AssemblyName { get; set; }

        public string ClassName { get; set; }

        public string MethodName { get; set; }

        public object[] Arguments { get; set; }

        public Type[] Types { get; set; }

        public object Instance { get; set; }
    }

    public static class ExternalMetodCaller
    {
        public static object Call(ExternalMethodCallerConfig config)
        {
            return CallBase(config);
        }

        private static object CallBase(ExternalMethodCallerConfig config)
        {
            var assembly = Assembly.Load(config.AssemblyName);
            var @class = assembly.GetType(config.ClassName);
            var method = @class.GetMethod(config.MethodName, config.Types);

            var result = method.Invoke(config.Instance, config.Arguments);
            return result;
        }
    }
}