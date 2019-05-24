using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("fieldAttr")]
    public class FieldAttrAstNode : AstNodeBase
    {
        public bool IsPublic { get; set; }

        public bool IsStatic { get; set; }

        public bool IsPrivate { get; set; }
        
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            var emptyChildren = AstChildren.Empty();
            if (emptyChildren.PopulateWith(parseNode))
            {
                IsPublic = false;
                IsStatic = false;

                return;
            }

            // fieldAttr + _("public")
            var publicChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("public");
            if (publicChildren.PopulateWith(parseNode))
            {
                IsPublic = true;
                IsStatic = publicChildren.Child1.IsStatic;
                IsPrivate = publicChildren.Child1.IsPrivate;

                return;
            }

            // fieldAttr + _("static")
            var staticChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("static");
            if (staticChildren.PopulateWith(parseNode))
            {
                IsPublic = staticChildren.Child1.IsPublic;
                IsStatic = true;
                IsPrivate = staticChildren.Child1.IsPrivate;

                return;
            }

            // fieldAttr + _("private")
            var privateChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("private");
            if (privateChildren.PopulateWith(parseNode))
            {
                IsPublic = privateChildren.Child1.IsPublic;
                IsStatic = privateChildren.Child1.IsStatic;
                IsPrivate = true;

                return;
            }

            // fieldAttr + _("family")
            var familyChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("family");
            if (familyChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                IsPublic = familyChildren.Child1.IsPublic;
                IsPrivate = familyChildren.Child1.IsPrivate;
                IsStatic = familyChildren.Child1.IsStatic;

                return;
            }

            // fieldAttr + _("assembly")
            var assemblyChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("assembly");
            if (assemblyChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                IsPublic = assemblyChildren.Child1.IsPublic;
                IsPrivate = assemblyChildren.Child1.IsPrivate;
                IsStatic = assemblyChildren.Child1.IsStatic;

                return;
            }

            // fieldAttr + _("specialname")
            var specialNameChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("specialname");
            if (specialNameChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                IsPublic = specialNameChildren.Child1.IsPublic;
                IsPrivate = specialNameChildren.Child1.IsPrivate;
                IsStatic = specialNameChildren.Child1.IsStatic;

                return;
            }

            // fieldAttr + _("rtspecialname")
            var rtspecialnameChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("rtspecialname");
            if (rtspecialnameChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                IsPublic = rtspecialnameChildren.Child1.IsPublic;
                IsPrivate = rtspecialnameChildren.Child1.IsPrivate;
                IsStatic = rtspecialnameChildren.Child1.IsStatic;

                return;
            }

            // fieldAttr + _("literal")
            var literalChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("literal");
            if (literalChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                IsPublic = literalChildren.Child1.IsPublic;
                IsPrivate = literalChildren.Child1.IsPrivate;
                IsStatic = literalChildren.Child1.IsStatic;

                return;
            }

            throw new NotImplementedException();
        }
    }
}