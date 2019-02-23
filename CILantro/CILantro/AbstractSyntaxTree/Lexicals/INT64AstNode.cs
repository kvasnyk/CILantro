using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Lexicals
{
    [AstNode("INT64")]
    public class INT64AstNode : AstNodeBase
    {
        public long Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            Value = Convert.ToInt64(parseNode.Token.Value);
        }
    }
}