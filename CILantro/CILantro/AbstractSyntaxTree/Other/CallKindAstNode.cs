using CILantro.Extensions;
using CILantro.Model;
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
            if (parseNode.ChildNodes.IsEmpty())
            {
                CallKind = CilCallKind.None;

                return;
            }

            throw new NotImplementedException();
        }
    }
}