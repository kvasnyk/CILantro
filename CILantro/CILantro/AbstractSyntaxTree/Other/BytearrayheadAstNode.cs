using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("bytearrayhead")]
    public class BytearrayheadAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _("bytearray") + _("(")
            var bytearrayChildren = AstChildren.Empty()
                .Add("bytearray")
                .Add("(");
            if (bytearrayChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            throw new NotImplementedException();
        }
    }
}