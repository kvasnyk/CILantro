using CILantro.Instructions;
using CILantro.Instructions.Field;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.InstuctionTypes
{
    [AstNode("INSTR_FIELD")]
    public class INSTR_FIELDAstNode : AstNodeBase
    {
        public CilInstructionField Instruction { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _("stsfld")
            var stsfldChildren = AstChildren.Empty()
                .Add("stsfld");
            if (stsfldChildren.PopulateWith(parseNode))
            {
                Instruction = new StoreStaticFieldInstruction();

                return;
            }

            // _("ldsfld")
            var ldsfldChildren = AstChildren.Empty()
                .Add("ldsfld");
            if (ldsfldChildren.PopulateWith(parseNode))
            {
                Instruction = new LoadStaticFieldInstruction();

                return;
            }

            throw new NotImplementedException();
        }
    }
}