using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("nameValPairs")]
    public class NameValPairsAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // nameValPair
            var nameValPairChildren = AstChildren.Empty()
                .Add<NameValPairAstNode>();
            if (nameValPairChildren.PopulateWith(parseNode))
            {
                // TODO: handle

                return;
            }

            throw new NotImplementedException();
        }
    }
}