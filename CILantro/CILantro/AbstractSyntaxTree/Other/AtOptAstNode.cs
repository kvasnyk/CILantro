using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("atOpt")]
    public class AtOptAstNode : AstNodeBase
    {
        public string AtId { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            var emptyChildren = AstChildren.Empty();
            if (emptyChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            // _("at") + id
            var atChildren = AstChildren.Empty()
                .Add("at")
                .Add<IdAstNode>();
            if (atChildren.PopulateWith(parseNode))
            {
                AtId = atChildren.Child2.Value;

                return;
            }

            throw new NotImplementedException();
        }
    }
}