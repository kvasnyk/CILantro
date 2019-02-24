using CILantro.Exceptions;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.InstuctionTypes
{
    [AstNode("INSTR_STRING")]
    public class INSTR_STRINGAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _("ldstr")
            var ldstrChildren = AstChildren.Empty()
                .Add("ldstr");
            if (ldstrChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            throw new InitAstNodeException(nameof(INSTR_STRINGAstNode));
        }
    }
}