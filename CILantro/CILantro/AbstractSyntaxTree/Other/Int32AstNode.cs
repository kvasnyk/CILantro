using CILantro.AbstractSyntaxTree.Lexicals;
using CILantro.Exceptions;
using CILantro.Extensions;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("int32")]
    public class Int32AstNode : AstNodeBase
    {
        public int Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            var astNode = parseNode.FindChild<INT32AstNode>();

            // INT32
            if (astNode != null)
            {
                Value = astNode.Value;

                return;
            }

            throw new InitAstNodeException(nameof(Int32AstNode));
        }
    }
}