using CILantro.Exceptions;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("localsHead")]
    public class LocalsHeadAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _(".locals")
            var localsChildren = AstChildren.Empty()
                .Add(".locals");
            if (localsChildren.PopulateWith(parseNode))
            {
                // TODO: handle

                return;
            }

            throw new InitAstNodeException(nameof(LocalsHeadAstNode));
        }
    }
}