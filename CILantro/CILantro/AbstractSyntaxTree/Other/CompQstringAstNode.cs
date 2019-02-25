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
        public string Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // QSTRING
            var qstringChildren = AstChildren.Empty()
                .Add<QSTRINGAstNode>();
            if (qstringChildren.PopulateWith(parseNode))
            {
                Value = qstringChildren.Child1.Value;

                return;
            }

            throw new NotImplementedException();
        }
    }
}