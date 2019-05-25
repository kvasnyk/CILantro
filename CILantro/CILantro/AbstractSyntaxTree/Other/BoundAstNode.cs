using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("bound")]
    public class BoundAstNode : AstNodeBase
    {
        public CilBound Bound { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // int32 + _("...")
            var int32dotsChildren = AstChildren.Empty()
                .Add<Int32AstNode>()
                .Add("...");
            if (int32dotsChildren.PopulateWith(parseNode))
            {
                Bound = new CilBound
                {
                    StartIndex = int32dotsChildren.Child1.Value,
                    HasDots = true
                };

                return;
            }

            throw new NotImplementedException();
        }
    }
}