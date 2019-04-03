using CILantro.AbstractSyntaxTree.InstuctionTypes;
using CILantro.Instructions;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("instr")]
    public class InstrAstNode : AstNodeBase
    {
        public CilInstruction Instruction { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // INSTR_NONE
            var noneChildren = AstChildren.Empty()
                .Add<INSTR_NONEAstNode>();
            if (noneChildren.PopulateWith(parseNode))
            {
                var instructionNone = noneChildren.Child1.Instruction;
                Instruction = instructionNone;

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
                var instructionMethod = methodTypeSpecChildren.Child1.Instruction;
                instructionMethod.ReturnType = methodTypeSpecChildren.Child3.Type;
                instructionMethod.TypeSpec = methodTypeSpecChildren.Child4.TypeSpec;
                instructionMethod.MethodName = methodTypeSpecChildren.Child6.MethodName;
                instructionMethod.SigArgs = methodTypeSpecChildren.Child8.SigArgs;

                Instruction = instructionMethod;

                return;
            }

            // INSTR_STRING + compQstring
            var stringQstringChildren = AstChildren.Empty()
                .Add<INSTR_STRINGAstNode>()
                .Add<CompQstringAstNode>();
            if (stringQstringChildren.PopulateWith(parseNode))
            {
                var instructionString = stringQstringChildren.Child1.Instruction;
                instructionString.StringValue = stringQstringChildren.Child2.Value;

                Instruction = instructionString;

                return;
            }

            throw new NotImplementedException();
        }
    }
}