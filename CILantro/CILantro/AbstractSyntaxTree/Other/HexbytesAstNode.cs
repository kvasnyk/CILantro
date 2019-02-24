using CILantro.AbstractSyntaxTree.Lexicals;
using CILantro.Exceptions;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("hexbytes")]
    public class HexbytesAstNode : AstNodeBase
    {
        public byte[] Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // HEXBYTE
            var hexbyteChildren = AstChildren.Empty()
                .Add<HEXBYTEAstNode>();
            if (hexbyteChildren.PopulateWith(parseNode))
            {
                Value = new byte[] { hexbyteChildren.Child1.Value };

                return;
            }

            // hexbytes + HEXBYTE
            var hexbytesChildren = AstChildren.Empty()
                .Add<HexbytesAstNode>()
                .Add<HEXBYTEAstNode>();
            if (hexbytesChildren.PopulateWith(parseNode))
            {
                var hexbytesNode = hexbytesChildren.Child1;
                Value = new byte[hexbytesNode.Value.Length + 1];
                Array.Copy(hexbytesNode.Value, Value, hexbytesNode.Value.Length);
                Value[Value.Length - 1] = hexbytesChildren.Child2.Value;

                return;
            }

            throw new InitAstNodeException(nameof(HexbytesAstNode));
        }
    }
}