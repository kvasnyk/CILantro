using CILantro.AbstractSyntaxTree.Lexicals;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("compQstring")]
    public class CompQstringAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // QSTRING
            var qstringChildren = AstChildren.Empty()
                .Add<QSTRINGAstNode>();
            if (qstringChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            throw new NotImplementedException();
        }
    }
}