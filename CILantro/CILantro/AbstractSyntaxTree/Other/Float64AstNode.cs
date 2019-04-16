using CILantro.AbstractSyntaxTree.Lexicals;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("float64")]
    public class Float64AstNode : AstNodeBase
    {
        public double Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // FLOAT64
            var float64Children = AstChildren.Empty()
                .Add<FLOAT64AstNode>();
            if (float64Children.PopulateWith(parseNode))
            {
                Value = float64Children.Child1.Value;

                return;
            }

            throw new NotImplementedException();
        }
    }
}