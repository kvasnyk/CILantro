using CILantro.Instructions;
using CILantro.Instructions.Br;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.InstuctionTypes
{
    [AstNode("INSTR_BRTARGET")]
    public class INSTR_BRTARGETAstNode : AstNodeBase
    {
        public CilInstructionBr Instruction { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // ___("brtrue.s")
            var brtruesChildren = AstChildren.Empty()
                .Add("brtrue.s");
            if (brtruesChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnTrueShortInstruction();

                return;
            }

            // ___("brfalse.s")
            var brfalsesChildren = AstChildren.Empty()
                .Add("brfalse.s");
            if (brfalsesChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnFalseShortInstruction();

                return;
            }

            // ___("br.s")
            var brsChildren = AstChildren.Empty()
                .Add("br.s");
            if (brsChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchShortInstruction();

                return;
            }

            // ___("bne.un.s")
            var bneunsChildren = AstChildren.Empty()
                .Add("bne.un.s");
            if (bneunsChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnNotEqualUnsignedShortInstruction();

                return;
            }

            // ___("beq.s")
            var beqsChildren = AstChildren.Empty()
                .Add("beq.s");
            if (beqsChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnEqualShortInstruction();

                return;
            }

            // ___("ble.s")
            var blesChildren = AstChildren.Empty()
                .Add("ble.s");
            if (blesChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnLessThanOrEqualToShortInstruction();

                return;
            }

            // ___("ble.un.s")
            var bleunsChildren = AstChildren.Empty()
                .Add("ble.un.s");
            if (bleunsChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnLessThanOrEqualToUnsignedShortInstruction();

                return;
            }

            throw new NotImplementedException();
        }
    }
}