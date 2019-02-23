using CILantro.Exceptions;
using CILantro.Extensions;
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
            if (parseNode.ChildNodes.IsEmpty())
            {
                Value = new byte[0];

                return;
            }

            // hexbytes
            if (parseNode.ChildNodes.Count == 1)
            {
                var hexbytesNode = parseNode.FindChild<HexbytesAstNode>();

                Value = hexbytesNode.Value;

                return;
            }

            throw new InitAstNodeException(nameof(BytesAstNode));
        }
    }
}