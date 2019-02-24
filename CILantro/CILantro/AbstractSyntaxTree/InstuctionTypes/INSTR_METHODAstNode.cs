using CILantro.Instructions;
using CILantro.Instructions.Method;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.InstuctionTypes
{
    [AstNode("INSTR_METHOD")]
    public class INSTR_METHODAstNode : AstNodeBase
    {
        public CilInstructionMethod Instruction { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _("call")
            var callChildren = AstChildren.Empty()
                .Add("call");
            if (callChildren.PopulateWith(parseNode))
            {
                Instruction = new CallInstruction();

                return;
            }

            throw new NotImplementedException();
        }
    }
}