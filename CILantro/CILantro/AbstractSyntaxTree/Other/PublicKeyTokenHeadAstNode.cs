using CILantro.Exceptions;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("publicKeyTokenHead")]
    public class PublicKeyTokenHeadAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // ___(".publickeytoken") + _("=") + _("(")
            if (parseNode.ChildNodes.Count == 3)
            {
                return;
            }

            throw new InitAstNodeException(nameof(PublicKeyTokenHeadAstNode));
        }
    }
}