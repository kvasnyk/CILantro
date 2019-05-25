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

            // INSTR_VAR + id
            var varIdChildren = AstChildren.Empty()
                .Add<INSTR_VARAstNode>()
                .Add<IdAstNode>();
            if (varIdChildren.PopulateWith(parseNode))
            {
                var instructionVar = varIdChildren.Child1.Instruction;
                instructionVar.Id = varIdChildren.Child2.Value;

                Instruction = instructionVar;

                return;
            }

            // INSTR_R + float64
            var instrRFloat64Children = AstChildren.Empty()
                .Add<INSTR_RAstNode>()
                .Add<Float64AstNode>();
            if (instrRFloat64Children.PopulateWith(parseNode))
            {
                var instructionR = instrRFloat64Children.Child1.Instruction;
                instructionR.Value = instrRFloat64Children.Child2.Value;

                Instruction = instructionR;

                return;
            }

            // INSTR_R + int64
            var instrRInt64Children = AstChildren.Empty()
                .Add<INSTR_RAstNode>()
                .Add<Int64AstNode>();
            if (instrRInt64Children.PopulateWith(parseNode))
            {
                var instructionR = instrRInt64Children.Child1.Instruction;
                instructionR.Value = instrRInt64Children.Child2.Value;

                Instruction = instructionR;

                return;
            }

            // INSTR_BRTARGET + id
            var instrBrIdChildren = AstChildren.Empty()
                .Add<INSTR_BRTARGETAstNode>()
                .Add<IdAstNode>();
            if (instrBrIdChildren.PopulateWith(parseNode))
            {
                var instructionBr = instrBrIdChildren.Child1.Instruction;
                instructionBr.Label = instrBrIdChildren.Child2.Value;

                Instruction = instructionBr;

                return;
            }

            // INSTR_FIELD + type + typeSpec + _("::") + id
            var instrField5Children = AstChildren.Empty()
                .Add<INSTR_FIELDAstNode>()
                .Add<TypeAstNode>()
                .Add<TypeSpecAstNode>()
                .Add("::")
                .Add<IdAstNode>();
            if (instrField5Children.PopulateWith(parseNode))
            {
                var instructionField = instrField5Children.Child1.Instruction;
                instructionField.FieldType = instrField5Children.Child2.Type;
                instructionField.ClassTypeSpec = instrField5Children.Child3.TypeSpec;
                instructionField.FieldId = instrField5Children.Child5.Value;

                Instruction = instructionField;

                return;
            }

            // INSTR_I8 + int64
            var instrI8Children = AstChildren.Empty()
                .Add<INSTR_I8AstNode>()
                .Add<Int64AstNode>();
            if (instrI8Children.PopulateWith(parseNode))
            {
                var instructionI8 = instrI8Children.Child1.Instruction;
                instructionI8.Value = instrI8Children.Child2.Value;

                Instruction = instructionI8;

                return;
            }

            // INSTR_SWITCH + _("(") + labels + _(")")
            var instrSwitchChildren = AstChildren.Empty()
                .Add<INSTR_SWITCHAstNode>()
                .Add("(")
                .Add<LabelsAstNode>()
                .Add(")");
            if (instrSwitchChildren.PopulateWith(parseNode))
            {
                var instructionSwitch = instrSwitchChildren.Child1.Instruction;
                instructionSwitch.SwitchLabels = instrSwitchChildren.Child3.Labels;

                Instruction = instructionSwitch;

                return;
            }

            // instr_tok_head + ownerType
            var instrTokChildren = AstChildren.Empty()
                .Add<Instr_tok_headAstNode>()
                .Add<OwnerTypeAstNode>();
            if (instrTokChildren.PopulateWith(parseNode))
            {
                var instructionTok = instrTokChildren.Child1.Instruction;
                instructionTok.TypeSpec = instrTokChildren.Child2.TypeSpec;
                instructionTok.FieldType = instrTokChildren.Child2.FieldType;
                instructionTok.FieldTypeSpec = instrTokChildren.Child2.FieldTypeSpec;
                instructionTok.FieldId = instrTokChildren.Child2.FieldId;

                Instruction = instructionTok;

                return;
            }

            throw new NotImplementedException();
        }
    }
}