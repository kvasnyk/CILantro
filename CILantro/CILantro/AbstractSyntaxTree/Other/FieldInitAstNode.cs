﻿using CILantro.Interpreting.Values;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("fieldInit")]
    public class FieldInitAstNode : AstNodeBase
    {
        public IValue InitValue { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _("int32") + _("(") + int64 + _(")")
            var int32Children = AstChildren.Empty()
                .Add("int32")
                .Add("(")
                .Add<Int64AstNode>()
                .Add(")");
            if (int32Children.PopulateWith(parseNode))
            {
                InitValue = new CilValueInt32((int)int32Children.Child3.Value);

                return;
            }

            throw new NotImplementedException();
        }
    }
}