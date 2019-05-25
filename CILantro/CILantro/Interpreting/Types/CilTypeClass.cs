using CILantro.Interpreting.Instances;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using CILantro.Utils;
using System;
using System.Linq;
using System.Reflection;

namespace CILantro.Interpreting.Types
{
    public class CilTypeClass : CilType
    {
        public CilClassName ClassName { get; }

        public override bool IsValueType(CilProgram program)
        {
            return program.IsValueType(ClassName);
        }

        public override bool IsNullable => throw new NotImplementedException();

        public CilTypeClass(CilClassName className)
        {
            ClassName = className;
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

            var @class = program.AllClasses.Single(c => c.Name.ToString() == ClassName.ToString());

            if (@class.IsInterface)
                return new CilValueNull();

            if (IsValueType(program))
            {
                var emptyInstance = new CilClassInstance(@class, program, null);
                return new CilValueValueType(emptyInstance);
            }

            return new CilValueNull();
        }

        private static T GetDefaultGeneric<T>()
        {
            return default(T);
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            if (program.IsExternalType(ClassName))
            {
                var cilObj = new CilObjectExternal(obj);
                var objRef = managedMemory.Store(cilObj);
                return objRef;
            }

            throw new NotImplementedException();
        }

        public override Type GetRuntimeType(CilProgram program)
        {
            if (program.IsExternalType(ClassName))
            {
                return ReflectionHelper.GetExternalType(ClassName);
            }

            throw new NotImplementedException();
        }

        public override Type GetValueType(CilProgram program)
        {
            if (IsValueType(program))
            {
                return typeof(CilValueValueType);
            }

            return typeof(CilValueReference);
        }

        public override bool IsAssignableFrom(CilType other)
        {
            if (other is CilTypeClass typeClass)
            {
                if (ClassName.ToString() == typeClass.ClassName.ToString())
                    return true;
            }

            throw new NotImplementedException();
        }

        public override IValue Unbox(CilObject obj, CilManagedMemory managedMemory, CilProgram program)
        {
            throw new NotImplementedException();
        }
    }
}