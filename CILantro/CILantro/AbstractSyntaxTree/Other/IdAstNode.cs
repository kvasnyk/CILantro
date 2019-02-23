using CILantro.AbstractSyntaxTree.Lexicals;
using CILantro.Extensions;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("id")]
    public class IdAstNode : AstNodeBase
    {
        public string Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            var IDNode = parseNode.FindChild<IDAstNode>();

            // ID
            if (IDNode != null)
            {
                Value = IDNode.Value;

                return;
            }

            throw new NotImplementedException();
        }
    }
}