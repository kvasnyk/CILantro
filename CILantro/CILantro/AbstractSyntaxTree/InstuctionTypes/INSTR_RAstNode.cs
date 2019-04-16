using CILantro.Exceptions;
using CILantro.Instructions;
using CILantro.Instructions.R;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.InstuctionTypes
{
    [AstNode("INSTR_R")]
    public class INSTR_RAstNode : AstNodeBase
    {
        public CilInstructionR Instruction { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // ___("ldc.r4")
            var ldcr4Children = AstChildren.Empty()
                .Add("ldc.r4");
            if (ldcr4Children.PopulateWith(parseNode))
            {
                Instruction = new LoadConstR4Instruction();

                return;
            }

            // ___("ldc.r8")
            var ldcr8Children = AstChildren.Empty()
                .Add("ldc.r8");
            if (ldcr8Children.PopulateWith(parseNode))
            {
                Instruction = new LoadConstR8Instruction();

                return;
            }

            throw new InitAstNodeException(nameof(INSTR_RAstNode));
        }
    }
}