using CILantro.Extensions;
using CILantro.Model;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    public enum DeclType
    {
        AssemblyRef
    }

    [AstNode("decl")]
    public class DeclAstNode : AstNodeBase
    {
        public DeclType? DeclType { get; private set; }

        public CilAssemblyRef AssemblyRefDecl { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            var assemblyRefHeadNode = parseNode.FindChild<AssemblyRefHeadAstNode>();
            var assemblyRefDeclsNode = parseNode.FindChild<AssemblyRefDeclsAstNode>();

            // assemblyRefHead + _("{") + assemblyRefDecls + _("}")
            if (assemblyRefHeadNode != null && assemblyRefDeclsNode != null)
            {
                DeclType = Other.DeclType.AssemblyRef;
                AssemblyRefDecl = new CilAssemblyRef
                {
                    Name = assemblyRefHeadNode.AssemblyName,
                    PublicKeyToken = assemblyRefDeclsNode.PublicKeyToken,
                    Version = assemblyRefDeclsNode.Version
                };

                return;
            }

            throw new NotImplementedException();
        }
    }
}