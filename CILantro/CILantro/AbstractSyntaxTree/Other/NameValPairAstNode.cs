using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("nameValPair")]
    public class NameValPairAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // className + _("=") + caValue
            var classNameChildren = AstChildren.Empty()
                .Add<ClassNameAstNode>()
                .Add("=")
                .Add<CaValueAstNode>();
            if (classNameChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            throw new NotImplementedException();
        }
    }
}