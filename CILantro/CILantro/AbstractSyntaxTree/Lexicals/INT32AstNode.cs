﻿using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Lexicals
{
    [AstNode("INT32")]
    public class INT32AstNode : AstNodeBase
    {
        public int Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            Value = Convert.ToInt32(parseNode.Token.Value);
        }
    }
}