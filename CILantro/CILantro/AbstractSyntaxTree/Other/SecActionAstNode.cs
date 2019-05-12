using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("secAction")]
    public class SecActionAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _("reqmin")
            var reqminChildren = AstChildren.Empty()
                .Add("reqmin");
            if (reqminChildren.PopulateWith(parseNode))
            {
                // TODO: handle

                return;
            }

            throw new NotImplementedException();
        }
    }
}