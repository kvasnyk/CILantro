using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CILantro.Structure
{
    public class CilProgram
    {
        public List<CilAssemblyRef> AssemblyRefs { get; }

        public List<CilAssembly> Assemblies { get; }

        public List<CilClass> Classes { get; }

        public List<CilMethod> Methods { get; }

        public List<CilMethod> AllMethods => Methods.Union(Classes.SelectMany(c => c.Methods)).ToList();

        public CilMethod EntryPoint => AllMethods.Single(m => m.IsEntryPoint);

        public CilProgram(CilDecls decls)
        {
            AssemblyRefs = decls.AssemblyRefs;
            Assemblies = decls.Assemblies;
            Classes = decls.Classes;
            Methods = decls.Methods;

            foreach (var @class in Classes)
            {
                var isExtendsExternal = IsExternalType(@class.ExtendsName);

                if (isExtendsExternal)
                {
                    // TODO: handle
                }
                else
                {
                    @class.Extends = Classes.First(c => c.Name.ToString() == @class.ExtendsName.ToString());
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

            throw new NotImplementedException();
        }

        public bool IsValueType(CilClassName className)
        {
            if (IsExternalType(className))
            {
                var assembly = Assembly.Load(className.AssemblyName);
                var type = assembly.GetType(className.ClassName);
                return type.IsValueType;
            }

            var @class = Classes.Single(c => c.Name.ToString() == className.ToString());
            var result = @class.ExtendsName.ToString() == "[mscorlib]System.ValueType" && @class.IsSequential;
            return result;
        }
    }
}