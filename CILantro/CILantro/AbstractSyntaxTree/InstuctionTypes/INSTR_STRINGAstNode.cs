using CILantro.Exceptions;
using CILantro.Instructions;
using CILantro.Instructions.String;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.InstuctionTypes
{
    [AstNode("INSTR_STRING")]
    public class INSTR_STRINGAstNode : AstNodeBase
    {
        public CilInstructionString Instruction { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _("ldstr")
            var ldstrChildren = AstChildren.Empty()
                .Add("ldstr");
            if (ldstrChildren.PopulateWith(parseNode))
            {
                Instruction = new LoadStringInstruction();

                return;
            }

            throw new InitAstNodeException(nameof(INSTR_STRINGAstNode));
        }
    }
}