using CILantro.AbstractSyntaxTree.Lexicals;
using CILantro.Exceptions;
using CILantro.Extensions;
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
            var HEXBYTENode = parseNode.FindChild<HEXBYTEAstNode>();

            // HEXBYTE
            if (parseNode.ChildNodes.Count == 1)
            {
                Value = new byte[] { HEXBYTENode.Value };

                return;
            }

            // hexbytes + HEXBYTE
            if (parseNode.ChildNodes.Count == 2)
            {
                var hexbytesNode = parseNode.FindChild<HexbytesAstNode>();

                Value = new byte[hexbytesNode.Value.Length + 1];
                Array.Copy(hexbytesNode.Value, Value, hexbytesNode.Value.Length);
                Value[Value.Length - 1] = HEXBYTENode.Value;

                return;
            }

            throw new InitAstNodeException(nameof(HexbytesAstNode));
        }
    }
}