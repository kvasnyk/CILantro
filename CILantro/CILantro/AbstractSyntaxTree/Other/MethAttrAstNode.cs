using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("methAttr")]
    public class MethAttrAstNode : AstNodeBase
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

            // methAttr + _("static")
            var staticChildren = AstChildren.Empty()
                .Add<MethAttrAstNode>()
                .Add("static");
            if (staticChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // methAttr + _("public")
            var publicChildren = AstChildren.Empty()
                .Add<MethAttrAstNode>()
                .Add("public");
            if (publicChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // methAttr + _("private")
            var privateChildren = AstChildren.Empty()
                .Add<MethAttrAstNode>()
                .Add("private");
            if (privateChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // methAttr + _("specialname")
            var specialNameChildren = AstChildren.Empty()
                .Add<MethAttrAstNode>()
                .Add("specialname");
            if (specialNameChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // methAttr + _("hidebysig")
            var hidebysigChildren = AstChildren.Empty()
                .Add<MethAttrAstNode>()
                .Add("hidebysig");
            if (hidebysigChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // methAttr + _("rtspecialname")
            var rtSpecialNameChildren = AstChildren.Empty()
                .Add<MethAttrAstNode>()
                .Add("rtspecialname");
            if (rtSpecialNameChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            throw new NotImplementedException();
        }
    }
}