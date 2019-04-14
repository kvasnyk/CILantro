using System;
using System.Collections.Generic;
using System.Linq;

namespace CILantro.Structure
{
    public class CilProgram
    {
        public List<CilAssemblyRef> AssemblyRefs { get; }

        public List<CilClass> Classes { get; }

        public CilMethod EntryPoint => Classes.Single(c => c.EntryPoint != null).EntryPoint;

        public CilProgram(CilDecls decls)
        {
            AssemblyRefs = decls.AssemblyRefs;
            Classes = decls.Classes;
        }

        public bool IsExternalType(CilTypeSpec typeSpec)
        {
            if (typeSpec.ClassName != null)
            {
                return AssemblyRefs.Any(ar => ar.Name == typeSpec.ClassName.AssemblyName);
            }

            throw new NotImplementedException();
        }
    }
}