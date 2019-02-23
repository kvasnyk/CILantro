using CILantro.Extensions;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("name1")]
    public class Name1AstNode : AstNodeBase
    {
        public string Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            var idNode = parseNode.FindChild<IdAstNode>();

            // id
            if (idNode != null)
            {
                Value = idNode.Value;

                return;
            }

            throw new NotImplementedException();
        }
    }
}