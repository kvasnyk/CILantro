using CILantro.Instructions;
using CILantro.Instructions.Switch;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.InstuctionTypes
{
    [AstNode("INSTR_SWITCH")]
    public class INSTR_SWITCHAstNode : AstNodeBase
    {
        public CilInstructionSwitch Instruction { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _("switch")
            var switchChildren = AstChildren.Empty()
                .Add("switch");
            if (switchChildren.PopulateWith(parseNode))
            {
                Instruction = new SwitchInstruction();

                return;
            }

            throw new NotImplementedException();
        }
    }
}