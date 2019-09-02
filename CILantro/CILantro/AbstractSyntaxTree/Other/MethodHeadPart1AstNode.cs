using CILantro.Exceptions;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("methodHeadPart1")]
    public class MethodHeadPart1AstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _(".method")
            var methodChildren = AstChildren.Empty()
                .Add(".method");
            if (methodChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            throw new InitAstNodeException(nameof(MethodHeadPart1AstNode));
        }
    }
}