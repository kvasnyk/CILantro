using CILantro.PorgramStructure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("callKind")]
    public class CallKindAstNode : AstNodeBase
    {
        public CilCallKind CallKind { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            var emptyChildren = AstChildren.Empty();
            if (emptyChildren.PopulateWith(parseNode))
            {
                CallKind = CilCallKind.None;

                return;
            }

            throw new NotImplementedException();
        }
    }
}