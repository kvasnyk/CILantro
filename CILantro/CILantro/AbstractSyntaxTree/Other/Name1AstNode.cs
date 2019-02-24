using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("name1")]
    public class Name1AstNode : AstNodeBase
    {
        public string Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // id
            var idChildren = AstChildren.Empty()
                .Add<IdAstNode>();
            if (idChildren.PopulateWith(parseNode))
            {
                Value = idChildren.Child1.Value;

                return;
            }

            // name1 + _(".") + name1
            var name1Children = AstChildren.Empty()
                .Add<Name1AstNode>()
                .Add(".")
                .Add<Name1AstNode>();
            if (name1Children.PopulateWith(parseNode))
            {
                Value = name1Children.Child1.Value + "." + name1Children.Child3.Value;

                return;
            }

            throw new NotImplementedException();
        }
    }
}