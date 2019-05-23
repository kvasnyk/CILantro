using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;
using System.Reflection;

namespace CILantro.Interpreting.Types
{
    public class CilTypeValueType : CilType
    {
        public CilClassName ClassName { get; }

        public override bool IsValueType => throw new NotImplementedException();

        public override bool IsNullable => throw new NotImplementedException();

        public CilTypeValueType(CilClassName className)
        {
            ClassName = className;
        }

        public override Type GetRuntimeType(CilProgram program)
        {
            var assembly = Assembly.Load(ClassName.AssemblyName);
            var type = assembly.GetType(ClassName.ClassName);
            return type;
        }

        public override Type GetValueType(CilProgram program)
        {
            if (program.IsExternalType(ClassName))
                return typeof(CilValueExternal);

            throw new NotImplementedException();
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            if (program.IsExternalType(ClassName))
                return new CilValueExternal(obj);

            throw new NotImplementedException();
        }

        public override IValue CreateDefaultValue(CilProgram program)
        {
            if (program.IsExternalType(ClassName))
            {
                var assembly = Assembly.Load(ClassName.AssemblyName);
                var type = assembly.GetType(ClassName.ClassName);

                var getDefault = GetType().GetMethod(nameof(GetDefaultGeneric), BindingFlags.NonPublic | BindingFlags.Static).MakeGenericMethod(type);
                var defaultValue = getDefault.Invoke(null, null);

                return new CilValueExternal(defaultValue);
            }

            throw new NotImplementedException();
        }

        private static T GetDefaultGeneric<T>()
        {
            return default(T);
        }

        public override bool IsAssignableFrom(CilType other)
        {
            throw new NotImplementedException();
        }
    }
}