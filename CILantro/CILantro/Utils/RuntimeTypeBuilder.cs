﻿using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Types;
using CILantro.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace CILantro.Utils
{
    public static class RuntimeTypeBuilder
    {
        private static int _counter = 0;

        private static Dictionary<string, Type> RegisteredTypes { get; set; } = new Dictionary<string, Type>();

        public static Type RegisterProxy(CilClassName className)
        {
            var assemblyName = new AssemblyName("CILantroProxiesAssembly");
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndCollect);

            var moduleBuilder = assemblyBuilder.DefineDynamicModule("CILantroProxiesModule");

            var parentType = ReflectionHelper.GetExternalType(className);

            var typeName = $"{className.ClassName}_CILantroProxy_{_counter}";
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

        public static Type RegisterType(CilClass cilClass, CilProgram program, CilManagedMemory managedMemory)
        {
            var typeName = $"{cilClass.Name.ClassName}";

            if (RegisteredTypes.ContainsKey(typeName))
                return RegisteredTypes[typeName];

            var assemblyName = new AssemblyName("CILantroTypesAssembly");
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndCollect);

            var moduleBuilder = assemblyBuilder.DefineDynamicModule("CILantroTypesModule");

            var parentType = ReflectionHelper.GetExternalType(cilClass.ExtendsName);

            var typeBuilder = moduleBuilder.DefineType(typeName, TypeAttributes.Class, parentType);

            RegisteredTypes.Add(typeName, typeBuilder);

            foreach (var field in cilClass.Fields)
            {
                Type resultType = null;
                if (field.Type is CilTypeClass fieldTypeClass)
                {
                    if (fieldTypeClass.ClassName.ToString() == cilClass.Name.ToString())
                        resultType = typeBuilder;
                }
                else if (field.Type is CilTypeValueType fieldTypeValueType)
                {
                    if (fieldTypeValueType.ClassName.ToString() == cilClass.Name.ToString())
                        resultType = typeBuilder;
                    else
                    {
                        var cilClass2 = program.AllClasses.Single(c => c.Name.ToString() == fieldTypeValueType.ClassName.ToString());
                        resultType = RegisterType(cilClass2, program, managedMemory);
                    }
                }
                else
                    resultType = field.Type.GetRuntimeType(program);

                var fieldBuilder = typeBuilder.DefineField(field.Name, resultType, field.GetRuntimeAttributes());
                
                if (field.IsStatic)
                {
                    fieldBuilder.SetConstant(field.InitValue.AsRuntime(field.Type, managedMemory, program));
                }
            }

            var type = typeBuilder.CreateType();
            RegisteredTypes[typeName] = type;

            _counter++;

            return type;
        }
    }
}