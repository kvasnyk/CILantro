using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Lexicals
{
    [AstNode("FLOAT64")]
    public class FLOAT64AstNode : AstNodeBase
    {
        public double Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            Value = Convert.ToDouble(parseNode.Token.Value);
        }
    }
}