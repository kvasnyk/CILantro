using CILantro.AbstractSyntaxTree.Lexicals;
using CILantro.Exceptions;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("int64")]
    public class Int64AstNode : AstNodeBase
    {
        public long Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // INT64
            var int64Children = AstChildren.Empty()
                .Add<INT64AstNode>();
            if (int64Children.PopulateWith(parseNode))
            {
                Value = int64Children.Child1.Value;

                return;
            }

            throw new InitAstNodeException(nameof(Int64AstNode));
        }
    }
}