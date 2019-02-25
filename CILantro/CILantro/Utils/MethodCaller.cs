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
    }

    public static class MethodCaller
    {
        public static void Call(MethodCallerConfig config)
        {
            CallBase(config, true);
        }

        private static object CallBase(MethodCallerConfig config, bool isVoid)
        {
            var assembly = Assembly.Load(config.AssemblyName);
            var @class = assembly.GetType(config.ClassName);
            var method = @class.GetMethod(config.MethodName, new Type[] { typeof(string) });

            method.Invoke(null, config.Arguments);

            return null;
        }
    }
}