using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Lexicals
{
    [AstNode("HEXBYTE")]
    public class HEXBYTEAstNode : AstNodeBase
    {
        public byte Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            Value = Convert.ToByte(parseNode.Token.ValueString, 16);
        }
    }
}