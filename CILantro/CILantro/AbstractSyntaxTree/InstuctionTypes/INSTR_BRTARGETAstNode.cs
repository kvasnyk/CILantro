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

            // ___("brtrue.s")
            var brtrueChildren = AstChildren.Empty()
                .Add("brtrue");
            if (brtrueChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnTrueInstruction();

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

            // ___("brfalse")
            var brfalseChildren = AstChildren.Empty()
                .Add("brfalse");
            if (brfalseChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnFalseInstruction();

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

            // ___("bne.un")
            var bneunChildren = AstChildren.Empty()
                .Add("bne.un");
            if (bneunChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnNotEqualUnsignedInstruction();

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

            // ___("beq")
            var beqChildren = AstChildren.Empty()
                .Add("beq");
            if (beqChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnEqualInstruction();

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

            // ___("ble")
            var bleChildren = AstChildren.Empty()
                .Add("ble");
            if (bleChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnLessThanOrEqualToInstruction();

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

            // ___("blt.s")
            var bltsChildren = AstChildren.Empty()
                .Add("blt.s");
            if (bltsChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnLessThanShortInstruction();

                return;
            }

            // ___("blt")
            var bltChildren = AstChildren.Empty()
                .Add("blt");
            if (bltChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnLessThanInstruction();

                return;
            }

            // ___("blt.un.s")
            var bltunsChildren = AstChildren.Empty()
                .Add("blt.un.s");
            if (bltunsChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnLessThanUnsignedShortInstruction();

                return;
            }

            // ___("blt.un")
            var bltunChildren = AstChildren.Empty()
                .Add("blt.un");
            if (bltunChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnLessThanUnsignedInstruction();

                return;
            }

            // ___("bge.s")
            var bgesChildren = AstChildren.Empty()
                .Add("bge.s");
            if (bgesChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnGreaterThanOrEqualToShortInstruction();

                return;
            }

            // ___("bge")
            var bgeChildren = AstChildren.Empty()
                .Add("bge");
            if (bgeChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnGreaterThanOrEqualToInstruction();

                return;
            }

            // ___("bge.un.s")
            var bgeunsChildren = AstChildren.Empty()
                .Add("bge.un.s");
            if (bgeunsChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnGreaterThanOrEqualToUnsignedShortInstruction();

                return;
            }

            // ___("bge.un")
            var bgeunChildren = AstChildren.Empty()
                .Add("bge.un");
            if (bgeunChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnGreaterThanOrEqualToUnsignedInstruction();

                return;
            }

            // ___("bgt.s")
            var bgtsChildren = AstChildren.Empty()
                .Add("bgt.s");
            if (bgtsChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnGreaterThanShortInstruction();

                return;
            }

            // ___("bgt")
            var bgtChildren = AstChildren.Empty()
                .Add("bgt");
            if (bgtChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnGreaterThanInstruction();

                return;
            }

            // ___("bgt.un.s")
            var bgtunsChildren = AstChildren.Empty()
                .Add("bgt.un.s");
            if (bgtunsChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnGreaterThanUnsignedShortInstruction();

                return;
            }

            // ___("bgt.un")
            var bgtunChildren = AstChildren.Empty()
                .Add("bgt.un");
            if (bgtunChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchOnGreaterThanUnsignedInstruction();

                return;
            }

            // _("br")
            var brChildren = AstChildren.Empty()
                .Add("br");
            if (brChildren.PopulateWith(parseNode))
            {
                Instruction = new BranchInstruction();

                return;
            }

            throw new NotImplementedException();
        }
    }
}