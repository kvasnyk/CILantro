using CILantro.AbstractSyntaxTree.Lexicals;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("caValue")]
    public class CaValueAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _("{") + _("property") + _("bool") + SQSTRING + _("=") + _("bool") + _("(") + _("true") + _(")") + _("}")
            var complexChildren = AstChildren.Empty()
                .Add("{")
                .Add("property")
                .Add("bool")
                .Add<SQSTRINGAstNode>()
                .Add("=")
                .Add("bool")
                .Add("(")
                .Add("true")
                .Add(")")
                .Add("}");
            if (complexChildren.PopulateWith(parseNode))
            {
                // TODO: handle

                return;
            }

            throw new NotImplementedException();
        }
    }
}