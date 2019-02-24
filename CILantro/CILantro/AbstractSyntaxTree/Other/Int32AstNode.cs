using CILantro.AbstractSyntaxTree.Lexicals;
using CILantro.Exceptions;
using CILantro.Utils;
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
            // INT32
            var int32Children = AstChildren.Empty()
                .Add<INT32AstNode>();
            if (int32Children.PopulateWith(parseNode))
            {
                Value = int32Children.Child1.Value;

                return;
            }

            throw new InitAstNodeException(nameof(Int32AstNode));
        }
    }
}