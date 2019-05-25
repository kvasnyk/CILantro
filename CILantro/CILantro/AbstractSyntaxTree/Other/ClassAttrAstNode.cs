using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [Flags]
    public enum CilClassAttributes
    {
        Default = 0x0,
        Sequential = 0x1,
        Interface = 0x2
    }

    [AstNode("classAttr")]
    public class ClassAttrAstNode : AstNodeBase
    {
        public CilClassAttributes ClassAttributes { get; private set; }

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
                ClassAttributes |= privateChildren.Child1.ClassAttributes;

                return;
            }

            // classAttr + _("auto")
            var autoChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("auto");
            if (autoChildren.PopulateWith(parseNode))
            {
                ClassAttributes |= autoChildren.Child1.ClassAttributes;

                return;
            }

            // classAttr + _("ansi")
            var ansiChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("ansi");
            if (ansiChildren.PopulateWith(parseNode))
            {
                // TODO: hanlde
                ClassAttributes |= ansiChildren.Child1.ClassAttributes;

                return;
            }

            // classAttr + _("beforefieldinit")
            var beforeFieldInitChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("beforefieldinit");
            if (beforeFieldInitChildren.PopulateWith(parseNode))
            {
                // TODO: handle;
                ClassAttributes |= beforeFieldInitChildren.Child1.ClassAttributes;

                return;
            }

            // classAttr + _("public")
            var publicChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("public");
            if (publicChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                ClassAttributes |= publicChildren.Child1.ClassAttributes;

                return;
            }

            // classAttr + _("abstract")
            var abstractChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("abstract");
            if (abstractChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                ClassAttributes |= abstractChildren.Child1.ClassAttributes;

                return;
            }

            // classAttr + _("sealed")
            var sealedChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("sealed");
            if (sealedChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                ClassAttributes |= sealedChildren.Child1.ClassAttributes;

                return;
            }

            // classAttr + _("sequential")
            var sequentialChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("sequential");
            if (sequentialChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                ClassAttributes |= sequentialChildren.Child1.ClassAttributes | CilClassAttributes.Sequential;

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
                ClassAttributes |= nestedPrivateChildren.Child1.ClassAttributes;

                return;
            }

            // classAttr + _("explicit")
            var explicitChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("explicit");
            if (explicitChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                ClassAttributes |= explicitChildren.Child1.ClassAttributes;

                return;
            }

            // classAttr + _("interface")
            var interfaceChildren = AstChildren.Empty()
                .Add<ClassAttrAstNode>()
                .Add("interface");
            if (interfaceChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                ClassAttributes |= interfaceChildren.Child1.ClassAttributes | CilClassAttributes.Interface;

                return;
            }

            throw new NotImplementedException();
        }
    }
}