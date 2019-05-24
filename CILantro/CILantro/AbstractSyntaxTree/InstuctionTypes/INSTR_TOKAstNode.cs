using CILantro.Instructions;
using CILantro.Instructions.Tok;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.InstuctionTypes
{
    [AstNode("INSTR_TOK")]
    public class INSTR_TOKAstNode : AstNodeBase
    {
        public CilInstructionTok Instruction { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _("ldtoken")
            var ldtokenChildren = AstChildren.Empty()
                .Add("ldtoken");
            if (ldtokenChildren.PopulateWith(parseNode))
            {
                Instruction = new LoadTokenInstruction();

                return;
            }

            throw new NotImplementedException();
        }
    }
}