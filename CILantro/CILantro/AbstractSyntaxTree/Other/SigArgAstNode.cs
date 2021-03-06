﻿using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("sigArg")]
    public class SigArgAstNode : AstNodeBase
    {
        public CilSigArg SigArg { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // paramAttr + type
            var children2 = AstChildren.Empty()
                .Add<ParamAttrAstNode>()
                .Add<TypeAstNode>();
            if (children2.PopulateWith(parseNode))
            {
                SigArg = new CilSigArg
                {
                    Type = children2.Child2.Type
                };

                return;
            }

            // paramAttr + type + id
            var idChildren = AstChildren.Empty()
                .Add<ParamAttrAstNode>()
                .Add<TypeAstNode>()
                .Add<IdAstNode>();
            if (idChildren.PopulateWith(parseNode))
            {
                SigArg = new CilSigArg
                {
                    Type = idChildren.Child2.Type,
                    Id = idChildren.Child3.Value
                };

                return;
            }

            throw new NotImplementedException();
        }
    }
}