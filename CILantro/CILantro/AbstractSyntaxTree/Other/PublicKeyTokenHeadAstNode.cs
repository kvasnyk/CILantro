using CILantro.Exceptions;
using CILantro.Utils;
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
            var children = AstChildren.Empty()
                .Add(".publickeytoken")
                .Add("=")
                .Add("(");
            if (children.PopulateWith(parseNode))
            {
                return;
            }

            throw new InitAstNodeException(nameof(PublicKeyTokenHeadAstNode));
        }
    }
}