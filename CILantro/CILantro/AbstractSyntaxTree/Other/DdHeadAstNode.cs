using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("ddHead")]
    public class DdHeadAstNode : AstNodeBase
    {
        public string DataId { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _(".data") + tls + id + _("=")
            var longChildren = AstChildren.Empty()
                .Add(".data")
                .Add<TlsAstNode>()
                .Add<IdAstNode>()
                .Add("=");
            if (longChildren.PopulateWith(parseNode))
            {
                DataId = longChildren.Child3.Value;

                return;
            }

            throw new NotImplementedException();
        }
    }
}