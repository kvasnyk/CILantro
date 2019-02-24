using CILantro.Exceptions;
using CILantro.Structure;
using CILantro.Utils;
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
            // _("instance") + callConv
            var instanceChildren = AstChildren.Empty()
                .Add("instance")
                .Add<CallConvAstNode>();
            if (instanceChildren.PopulateWith(parseNode))
            {
                CallConv = CilCallConv.Instance;
                CallKind = instanceChildren.Child2.CallKind;

                return;
            }

            // _("explicit") + callConv
            var explicitChildren = AstChildren.Empty()
                .Add("explicit")
                .Add<CallConvAstNode>();
            if (explicitChildren.PopulateWith(parseNode))
            {
                CallConv = CilCallConv.Explicit;
                CallKind = explicitChildren.Child2.CallKind;

                return;
            }

            // callKind
            var callKindChildren = AstChildren.Empty()
                .Add<CallKindAstNode>();
            if (callKindChildren.PopulateWith(parseNode))
            {
                CallKind = callKindChildren.Child1.CallKind;

                return;
            }

            throw new InitAstNodeException(nameof(CallConvAstNode));
        }
    }
}