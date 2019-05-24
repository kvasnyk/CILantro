using CILantro.AbstractSyntaxTree.InstuctionTypes;
using CILantro.Instructions;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("instr_tok_head")]
    public class Instr_tok_headAstNode : AstNodeBase
    {
        public CilInstructionTok Instruction { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // INSTR_TOK
            var instrTokChildren = AstChildren.Empty()
                .Add<INSTR_TOKAstNode>();
            if (instrTokChildren.PopulateWith(parseNode))
            {
                Instruction = instrTokChildren.Child1.Instruction;

                return;
            }

            throw new NotImplementedException();
        }
    }
}