using CILantro.Exceptions;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("bytes")]
    public class BytesAstNode : AstNodeBase
    {
        public byte[] Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            var emptyChildren = AstChildren.Empty();
            if (emptyChildren.PopulateWith(parseNode))
            {
                Value = new byte[0];

                return;
            }

            // hexbytes
            var hexbytesChildren = AstChildren.Empty()
                .Add<HexbytesAstNode>();
            if (hexbytesChildren.PopulateWith(parseNode))
            {
                Value = hexbytesChildren.Child1.Value;

                return;
            }

            throw new InitAstNodeException(nameof(BytesAstNode));
        }
    }
}