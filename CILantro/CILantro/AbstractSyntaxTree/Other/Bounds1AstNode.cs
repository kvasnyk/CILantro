using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;
using System.Collections.Generic;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("bounds1")]
    public class Bounds1AstNode : AstNodeBase
    {
        public List<CilBound> Bounds { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // bound
            var boundChildren = AstChildren.Empty()
                .Add<BoundAstNode>();
            if (boundChildren.PopulateWith(parseNode))
            {
                Bounds = new List<CilBound> { boundChildren.Child1.Bound };

                return;
            }

            // bounds1 + _(",") + bound
            var bounds1Children = AstChildren.Empty()
                .Add<Bounds1AstNode>()
                .Add(",")
                .Add<BoundAstNode>();
            if (bounds1Children.PopulateWith(parseNode))
            {
                Bounds = bounds1Children.Child1.Bounds;
                Bounds.Add(bounds1Children.Child3.Bound);

                return;
            }

            throw new NotImplementedException();
        }
    }
}