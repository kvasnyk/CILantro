using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.Lexicals
{
    [AstNode("ID")]
    public class IDAstNode : AstNodeBase
    {
        public string Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            Value = parseNode.Token.ValueString;
        }
    }
}