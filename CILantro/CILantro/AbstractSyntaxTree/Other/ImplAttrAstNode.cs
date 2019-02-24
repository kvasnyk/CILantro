using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("implAttr")]
    public class ImplAttrAstNode : AstNodeBase
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

            // implAttr + _("cil")
            var cilChildren = AstChildren.Empty()
                .Add<ImplAttrAstNode>()
                .Add("cil");
            if (cilChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // implAttr + _("managed")
            var managedChildren = AstChildren.Empty()
                .Add<ImplAttrAstNode>()
                .Add("managed");
            if (managedChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            throw new NotImplementedException();
        }
    }
}