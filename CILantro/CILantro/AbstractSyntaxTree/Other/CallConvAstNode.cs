using CILantro.Exceptions;
using CILantro.Extensions;
using CILantro.Model;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("callConv")]
    public class CallConvAstNode : AstNodeBase
    {
        // TODO: is only one value possible or should it be changed to list?
        public CilCallKind CallKind { get; private set; }

        // TODO: is only one value possible or should it be changed to list?
        public CilCallConv CallConv { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            var callKindNode = parseNode.FindChild<CallKindAstNode>();
            var callConvNode = parseNode.FindChild<CallConvAstNode>();

            // _("instance") + callConv
            if (parseNode.HasKeyChild("instance"))
            {
                CallConv = CilCallConv.Instance;
                CallKind = callConvNode.CallKind;

                return;
            }

            // _("explicit") + callConv
            if (parseNode.HasKeyChild("explicit"))
            {
                CallConv = CilCallConv.Explicit;
                CallKind = callConvNode.CallKind;

                return;
            }

            // callKind
            if (callKindNode != null)
            {
                CallKind = callKindNode.CallKind;

                return;
            }

            throw new InitAstNodeException(nameof(CallConvAstNode));
        }
    }
}