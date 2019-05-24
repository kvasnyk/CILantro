using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("slashedName")]
    public class SlashedNameAstNode : AstNodeBase
    {
        public string Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // name1
            var name1Children = AstChildren.Empty()
                .Add<Name1AstNode>();
            if (name1Children.PopulateWith(parseNode))
            {
                Value = name1Children.Child1.Value;

                return;
            }

            // slashedName + _("/") + name1
            var slashedNameChildren = AstChildren.Empty()
                .Add<SlashedNameAstNode>()
                .Add("/")
                .Add<Name1AstNode>();
            if (slashedNameChildren.PopulateWith(parseNode))
            {
                Value = slashedNameChildren.Child1.Value + "/" + slashedNameChildren.Child3.Value;

                return;
            }

            throw new NotImplementedException();
        }
    }
}