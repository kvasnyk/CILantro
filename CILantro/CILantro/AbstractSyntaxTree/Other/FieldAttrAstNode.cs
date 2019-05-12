using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("fieldAttr")]
    public class FieldAttrAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            var emptyChildren = AstChildren.Empty();
            if (emptyChildren.PopulateWith(parseNode))
            {
                // TODO: handle

                return;
            }

            // fieldAttr + _("public")
            var publicChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("public");
            if (publicChildren.PopulateWith(parseNode))
            {
                // TODO: handle

                return;
            }

            // fieldAttr + _("static")
            var staticChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("static");
            if (staticChildren.PopulateWith(parseNode))
            {
                // TODO: handle

                return;
            }

            throw new NotImplementedException();
        }
    }
}