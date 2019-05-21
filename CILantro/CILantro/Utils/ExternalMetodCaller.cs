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

        public bool CallConstructor { get; set; }

        public bool IsInstanceCall { get; set; }

        public bool IsMethodPublic { get; set; }
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

            var flags = BindingFlags.Default | BindingFlags.Public | BindingFlags.NonPublic;
            if (config.IsInstanceCall)
                flags |= BindingFlags.Instance;
            else
                flags |= BindingFlags.Static;

            if (config.CallConstructor)
            {
                var ctor = @class.GetConstructor(flags, null, config.Types, null);
                var result = ctor.Invoke(config.Instance, config.Arguments);
                return result;
            }
            else
            {
                var method = @class.GetMethod(config.MethodName, flags, null, config.Types, null);
                var result = method.Invoke(config.Instance, config.Arguments);
                return result;
            }
        }
    }
}