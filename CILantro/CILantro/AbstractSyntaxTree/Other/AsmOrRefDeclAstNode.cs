﻿using CILantro.ProgramStructure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    public enum AsmOrRefDeclType
    {
        Ver
    }

    [AstNode("asmOrRefDecl")]
    public class AsmOrRefDeclAstNode : AstNodeBase
    {
        public AsmOrRefDeclType? DeclType { get; private set; }

        public CilAssemblyVersion Version { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _(".ver") + int32 + _(":") + int32 + _(":") + int32 + _(":") + int32
            var verChildren = AstChildren.Empty()
                .Add(".ver")
                .Add<Int32AstNode>()
                .Add(":")
                .Add<Int32AstNode>()
                .Add(":")
                .Add<Int32AstNode>()
                .Add(":")
                .Add<Int32AstNode>();
            if (verChildren.PopulateWith(parseNode))
            {
                DeclType = AsmOrRefDeclType.Ver;
                Version = new CilAssemblyVersion(verChildren.Child2.Value, verChildren.Child4.Value, verChildren.Child6.Value, verChildren.Child8.Value);

                return;
            }

            // customAttrDecl
            var customAttrDeclChildren = AstChildren.Empty()
                .Add<CustomAttrDeclAstNode>();
            if (customAttrDeclChildren.PopulateWith(parseNode))
            {
                // TODO: what to do here?
                return;
            }

            throw new NotImplementedException();
        }
    }
}