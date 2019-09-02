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
                // TODO - handle
                return;
            }

            // methAttr + _("static")
            var staticChildren = AstChildren.Empty()
                .Add<MethAttrAstNode>()
                .Add("static");
            if (staticChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            // methAttr + _("public")
            var publicChildren = AstChildren.Empty()
                .Add<MethAttrAstNode>()
                .Add("public");
            if (publicChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            // methAttr + _("private")
            var privateChildren = AstChildren.Empty()
                .Add<MethAttrAstNode>()
                .Add("private");
            if (privateChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            // methAttr + _("specialname")
            var specialNameChildren = AstChildren.Empty()
                .Add<MethAttrAstNode>()
                .Add("specialname");
            if (specialNameChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            // methAttr + _("hidebysig")
            var hidebysigChildren = AstChildren.Empty()
                .Add<MethAttrAstNode>()
                .Add("hidebysig");
            if (hidebysigChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            // methAttr + _("rtspecialname")
            var rtSpecialNameChildren = AstChildren.Empty()
                .Add<MethAttrAstNode>()
                .Add("rtspecialname");
            if (rtSpecialNameChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            // methAttr + _("newslot")
            var newslotChildren = AstChildren.Empty()
                .Add<MethAttrAstNode>()
                .Add("newslot");
            if (newslotChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            // methAttr + _("virtual")
            var virtualChildren = AstChildren.Empty()
                .Add<MethAttrAstNode>()
                .Add("virtual");
            if (virtualChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            // methAttr + _("family")
            var familyChildren = AstChildren.Empty()
                .Add<MethAttrAstNode>()
                .Add("family");
            if (familyChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            // methAttr + _("abstract")
            var abstractChildren = AstChildren.Empty()
                .Add<MethAttrAstNode>()
                .Add("abstract");
            if (abstractChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            // methAttr + _("final")
            var finalChildren = AstChildren.Empty()
                .Add<MethAttrAstNode>()
                .Add("final");
            if (finalChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            throw new NotImplementedException();
        }
    }
}