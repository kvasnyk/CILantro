using CILantro.Interpreting.Types;
using CILantro.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CILantro.Structure
{
    public class CilProgram
    {
        public Dictionary<string, CilData> Datas { get; }

        public List<CilAssemblyRef> AssemblyRefs { get; }

        public List<CilAssembly> Assemblies { get; }

        public List<CilClass> Classes { get; }

        private List<CilClass> _allClasses;

        public List<CilClass> AllClasses
        {
            get
            {
                if (_allClasses != null)
                    return _allClasses;

                var result = Classes.SelectMany(c => GetAllAndNestedClasses(c)).ToList();
                _allClasses = result;
                return result;
            }
        }

        public List<CilMethod> Methods { get; }

        public List<CilMethod> AllMethods => Methods.Union(Classes.SelectMany(c => c.Methods)).ToList();

        public CilMethod EntryPoint => AllMethods.Single(m => m.IsEntryPoint);

        public CilProgram(CilDecls decls)
        {
            Datas = decls.Datas;
            AssemblyRefs = decls.AssemblyRefs;
            Assemblies = decls.Assemblies;
            Classes = decls.Classes;
            Methods = decls.Methods;

            foreach (var @class in Classes)
            {
                if (@class.IsInterface)
                    continue;

                var isExtendsExternal = IsExternalType(@class.ExtendsName);

                if (isExtendsExternal)
                {
                }
                else
                {
                    @class.Extends = Classes.First(c => c.Name.ToString() == @class.ExtendsName.ToString());
                }

                foreach (var field in @class.Fields)
                {
                    if (!string.IsNullOrEmpty(field.AtId))
                    {
                        var atData = Datas[field.AtId];
                        field.InitValue = atData.GetValue();
                    }
                }
            }
        }

        public bool IsExternalType(CilClassName className)
        {
            return AssemblyRefs.Any(ar => ar.Name == className.AssemblyName);
        }

        public bool IsExternalType(CilTypeSpec typeSpec)
        {
            if (typeSpec.ClassName != null)
                return IsExternalType(typeSpec.ClassName);

            if (typeSpec.Type is CilTypeArray typeArray)
            {
                if (typeArray.Dimensions == 1)
                    return false;
                else
                    return true;
            }

            throw new NotImplementedException();
        }

        public bool IsValueType(CilClassName className)
        {
            if (IsExternalType(className))
            {
                var type = ReflectionHelper.GetExternalType(className);
                return type.IsValueType;
            }

            var @class = AllClasses.Single(c => c.Name.ToString() == className.ToString());

            if (@class.IsInterface)
                return false;

            var result = @class.ExtendsName.ToString() == "[mscorlib]System.ValueType" || @class.ExtendsName.ToString() == "[mscorlib]System.Enum";
            return result;
        }

        private List<CilClass> GetAllAndNestedClasses(CilClass cilClass, string prefix = "")
        {
            var result = new List<CilClass>();

            if (!string.IsNullOrEmpty(prefix))
                cilClass.Name.ClassName = prefix + cilClass.Name.ClassName;

            result.Add(cilClass);

            var newPrefix = prefix + cilClass.Name.ClassName + "/";

            if (cilClass.Classes != null)
                result.AddRange(cilClass.Classes.SelectMany(nc => GetAllAndNestedClasses(nc, newPrefix)));

            return result;
        }
    }
}