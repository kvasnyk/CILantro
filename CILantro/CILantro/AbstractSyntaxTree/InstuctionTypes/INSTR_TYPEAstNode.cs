using CILantro.Instructions;
using CILantro.Instructions.Type;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.InstuctionTypes
{
    [AstNode("INSTR_TYPE")]
    public class INSTR_TYPEAstNode : AstNodeBase
    {
        public CilInstructionType Instruction { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _("newarr")
            var newarrChildren = AstChildren.Empty()
                .Add("newarr");
            if (newarrChildren.PopulateWith(parseNode))
            {
                Instruction = new NewArrayInstruction();

                return;
            }

            throw new NotImplementedException();
        }
    }
}