using CILantro.Instructions;
using CILantro.Instructions.I8;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.InstuctionTypes
{
    [AstNode("INSTR_I8")]
    public class INSTR_I8AstNode : AstNodeBase
    {
        public CilInstructionI8 Instruction { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // ___("ldc.i8")
            var ldci8Children = AstChildren.Empty()
                .Add("ldc.i8");
            if (ldci8Children.PopulateWith(parseNode))
            {
                Instruction = new LoadConstI8Instruction();

                return;
            }

            throw new System.NotImplementedException();
        }
    }
}