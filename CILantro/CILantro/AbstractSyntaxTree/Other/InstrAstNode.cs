using CILantro.AbstractSyntaxTree.InstuctionTypes;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("instr")]
    public class InstrAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // INSTR_NONE
            var noneChildren = AstChildren.Empty()
                .Add<INSTR_NONEAstNode>();
            if (noneChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // INSTR_METHOD + callConv + type + typeSpec + _("::") + methodName + _("(") + sigArgs0 + _(")")
            var methodTypeSpecChildren = AstChildren.Empty()
                .Add<INSTR_METHODAstNode>()
                .Add<CallConvAstNode>()
                .Add<TypeAstNode>()
                .Add<TypeSpecAstNode>()
                .Add("::")
                .Add<MethodNameAstNode>()
                .Add("(")
                .Add<SigArgs0AstNode>()
                .Add(")");
            if (methodTypeSpecChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // INSTR_STRING + compQstring
            var stringQstringChildren = AstChildren.Empty()
                .Add<INSTR_STRINGAstNode>()
                .Add<CompQstringAstNode>();
            if (stringQstringChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            throw new NotImplementedException();
        }
    }
}