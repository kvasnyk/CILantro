﻿using CILantro.AbstractSyntaxTree.InstuctionTypes;
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
                instructionMethod.CallConv = methodTypeSpecChildren.Child2.CallConv;
                instructionMethod.CallKind = methodTypeSpecChildren.Child2.CallKind;

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

            // INSTR_I + int32
            var iChildren = AstChildren.Empty()
                .Add<INSTR_IAstNode>()
                .Add<Int32AstNode>();
            if (iChildren.PopulateWith(parseNode))
            {
                var instructionI = iChildren.Child1.Instruction;
                instructionI.Value = iChildren.Child2.Value;

                Instruction = instructionI;

                return;
            }

            // INSTR_TYPE + typeSpec
            var typeChildren = AstChildren.Empty()
                .Add<INSTR_TYPEAstNode>()
                .Add<TypeSpecAstNode>();
            if (typeChildren.PopulateWith(parseNode))
            {
                var instructionType = typeChildren.Child1.Instruction;
                instructionType.TypeSpec = typeChildren.Child2.TypeSpec;

                Instruction = instructionType;

                return;
            }

            throw new NotImplementedException();
        }
    }
}