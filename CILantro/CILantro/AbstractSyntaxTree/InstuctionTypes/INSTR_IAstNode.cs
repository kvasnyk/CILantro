using CILantro.Instructions;
using CILantro.Instructions.I;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.InstuctionTypes
{
    [AstNode("INSTR_I")]
    public class INSTR_IAstNode : AstNodeBase
    {
        public CilInstructionI Instruction { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // ___("ldc.i4.s")
            var ldci4sChildren = AstChildren.Empty()
                .Add("ldc.i4.s");
            if (ldci4sChildren.PopulateWith(parseNode))
            {
                Instruction = new LoadConstI4ShortInstruction();

                return;
            }

            throw new NotImplementedException();
        }
    }
}