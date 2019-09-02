using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("manresAttr")]
    public class ManresAttrAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            var children0 = AstChildren.Empty();
            if (children0.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            // manresAttr + _("public")
            var publicChildren = AstChildren.Empty()
                .Add<ManresAttrAstNode>()
                .Add("public");
            if (publicChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            throw new NotImplementedException();
        }
    }
}