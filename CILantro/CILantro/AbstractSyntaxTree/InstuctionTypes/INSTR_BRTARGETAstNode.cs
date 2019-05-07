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

            throw new NotImplementedException();
        }
    }
}