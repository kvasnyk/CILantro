using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("classAttr")]
    public class ClassAttrAstNode : AstNodeBase
    {
        public bool IsSequential { get; private set; }

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
                IsSequential = privateChildren.Child1.IsSequential;

                return;
            }

            // classAttr + _("auto")
            var autoChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("auto");
            if (autoChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                IsSequential = autoChildren.Child1.IsSequential;

                return;
            }

            // classAttr + _("ansi")
            var ansiChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("ansi");
            if (ansiChildren.PopulateWith(parseNode))
            {
                // TODO: hanlde
                IsSequential = ansiChildren.Child1.IsSequential;

                return;
            }

            // classAttr + _("beforefieldinit")
            var beforeFieldInitChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("beforefieldinit");
            if (beforeFieldInitChildren.PopulateWith(parseNode))
            {
                // TODO: handle;
                IsSequential = beforeFieldInitChildren.Child1.IsSequential;

                return;
            }

            // classAttr + _("public")
            var publicChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("public");
            if (publicChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                IsSequential = publicChildren.Child1.IsSequential;

                return;
            }

            // classAttr + _("abstract")
            var abstractChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("abstract");
            if (abstractChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                IsSequential = abstractChildren.Child1.IsSequential;

                return;
            }

            // classAttr + _("sealed")
            var sealedChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("sealed");
            if (sealedChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                IsSequential = sealedChildren.Child1.IsSequential;

                return;
            }

            // classAttr + _("sequential")
            var sequentialChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("sequential");
            if (sequentialChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                IsSequential = true;

                return;
            }

            // classAttr + _("nested") + _("private")
            var nestedPrivateChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("nested")
                .Add("private");
            if (nestedPrivateChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                IsSequential = nestedPrivateChildren.Child1.IsSequential;

                return;
            }

            // classAttr + _("explicit")
            var explicitChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("explicit");
            if (explicitChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                IsSequential = explicitChildren.Child1.IsSequential;

                return;
            }

            throw new NotImplementedException();
        }
    }
}