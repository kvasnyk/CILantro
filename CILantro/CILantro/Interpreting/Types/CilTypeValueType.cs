using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using CILantro.Utils;
using System;
using System.Reflection;

namespace CILantro.Interpreting.Types
{
    public class CilTypeValueType : CilType
    {
        public CilClassName ClassName { get; }

        public override bool IsValueType(CilProgram program)
        {
            throw new NotImplementedException();
        }

        public override bool IsNullable => throw new NotImplementedException();

        public CilTypeValueType(CilClassName className)
        {
            ClassName = className;
        }

        public override Type GetRuntimeType(CilProgram program)
        {
            return ReflectionHelper.GetExternalType(ClassName);
        }

        public override Type GetValueType(CilProgram program)
        {
            if (program.IsExternalType(ClassName))
                return typeof(CilValueExternal);

            return typeof(CilValueValueType);
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
                var type = ReflectionHelper.GetExternalType(ClassName);

                var getDefault = GetType().GetMethod(nameof(GetDefaultGeneric), BindingFlags.NonPublic | BindingFlags.Static).MakeGenericMethod(type);
                var defaultValue = getDefault.Invoke(null, null);

                return new CilValueExternal(defaultValue);
            }

            var classType = new CilTypeClass(ClassName);
            return classType.CreateDefaultValue(program);
        }

        public static T GetDefaultGeneric<T>()
        {
            return default(T);
        }

        public override bool IsAssignableFrom(CilType other)
        {
            throw new NotImplementedException();
        }

        public override IValue Unbox(CilObject obj, CilManagedMemory managedMemory, CilProgram program)
        {
            if (obj is CilObjectExternal objExternal)
            {
                if (objExternal.ExternalObject.GetType().IsEnum)
                {
                    var result = Convert.ToInt32(objExternal.ExternalObject);
                    return new CilValueInt32(result);
                }
            }

            throw new NotImplementedException();
        }
    }
}