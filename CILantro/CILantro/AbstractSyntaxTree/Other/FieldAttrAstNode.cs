using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [Flags]
    public enum CilFieldAttributes
    {
        Default = 0x0,
        Public = 0x1,
        Static = 0x2,
        Private = 0x4
    }

    [AstNode("fieldAttr")]
    public class FieldAttrAstNode : AstNodeBase
    {
        public CilFieldAttributes FieldAttributes { get; private set; }
        
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            var emptyChildren = AstChildren.Empty();
            if (emptyChildren.PopulateWith(parseNode))
            {
                FieldAttributes = CilFieldAttributes.Default;

                return;
            }

            // fieldAttr + _("public")
            var publicChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("public");
            if (publicChildren.PopulateWith(parseNode))
            {
                FieldAttributes |= publicChildren.Child1.FieldAttributes | CilFieldAttributes.Public;

                return;
            }

            // fieldAttr + _("static")
            var staticChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("static");
            if (staticChildren.PopulateWith(parseNode))
            {
                FieldAttributes |= staticChildren.Child1.FieldAttributes | CilFieldAttributes.Static;

                return;
            }

            // fieldAttr + _("private")
            var privateChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("private");
            if (privateChildren.PopulateWith(parseNode))
            {
                FieldAttributes |= privateChildren.Child1.FieldAttributes | CilFieldAttributes.Private;

                return;
            }

            // fieldAttr + _("family")
            var familyChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("family");
            if (familyChildren.PopulateWith(parseNode))
            {
                FieldAttributes |= familyChildren.Child1.FieldAttributes;

                return;
            }

            // fieldAttr + _("assembly")
            var assemblyChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("assembly");
            if (assemblyChildren.PopulateWith(parseNode))
            {
                FieldAttributes |= assemblyChildren.Child1.FieldAttributes;

                return;
            }

            // fieldAttr + _("specialname")
            var specialNameChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("specialname");
            if (specialNameChildren.PopulateWith(parseNode))
            {
                FieldAttributes |= specialNameChildren.Child1.FieldAttributes;

                return;
            }

            // fieldAttr + _("rtspecialname")
            var rtspecialnameChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("rtspecialname");
            if (rtspecialnameChildren.PopulateWith(parseNode))
            {
                FieldAttributes |= rtspecialnameChildren.Child1.FieldAttributes;

                return;
            }

            // fieldAttr + _("literal")
            var literalChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("literal");
            if (literalChildren.PopulateWith(parseNode))
            {
                FieldAttributes |= literalChildren.Child1.FieldAttributes;

                return;
            }

            // fieldAttr + _("initonly")
            var initonlyChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("initonly");
            if (initonlyChildren.PopulateWith(parseNode))
            {
                FieldAttributes |= initonlyChildren.Child1.FieldAttributes;

                return;
            }

            throw new NotImplementedException();
        }
    }
}