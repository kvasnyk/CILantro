using CILantro.AbstractSyntaxTree.Lexicals;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("id")]
    public class IdAstNode : AstNodeBase
    {
        public string Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // ID
            var IDChildren = AstChildren.Empty()
                .Add<IDAstNode>();
            if (IDChildren.PopulateWith(parseNode))
            {
                Value = IDChildren.Child1.Value;

                return;
            }

            throw new NotImplementedException();
        }
    }
}