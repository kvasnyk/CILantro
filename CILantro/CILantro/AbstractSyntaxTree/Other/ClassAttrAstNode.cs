using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("classAttr")]
    public class ClassAttrAstNode : AstNodeBase
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

            // classAttr + _("private")
            var privateChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("private");
            if (privateChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // classAttr + _("auto")
            var autoChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("auto");
            if (autoChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // classAttr + _("ansi")
            var ansiChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("ansi");
            if (ansiChildren.PopulateWith(parseNode))
            {
                // TODO: hanlde
                return;
            }

            // classAttr + _("beforefieldinit")
            var beforeFieldInitChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("beforefieldinit");
            if (beforeFieldInitChildren.PopulateWith(parseNode))
            {
                // TODO: handle;
                return;
            }

            // classAttr + _("public")
            var publicChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("public");
            if (publicChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // classAttr + _("abstract")
            var abstractChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("abstract");
            if (abstractChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // classAttr + _("sealed")
            var sealedChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("sealed");
            if (sealedChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            throw new NotImplementedException();
        }
    }
}