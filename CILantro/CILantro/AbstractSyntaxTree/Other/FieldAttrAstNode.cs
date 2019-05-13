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

                return;
            }

            // fieldAttr + _("static")
            var staticChildren = AstChildren.Empty()
                .Add<FieldAttrAstNode>()
                .Add("static");
            if (staticChildren.PopulateWith(parseNode))
            {
                IsPublic = publicChildren.Child1.IsPublic;
                IsStatic = true;

                return;
            }

            throw new NotImplementedException();
        }
    }
}