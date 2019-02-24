using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.Lexicals
{
    [AstNode("QSTRING")]
    public class QSTRINGAstNode : AstNodeBase
    {
        public string Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            Value = parseNode.Token.ValueString;

            return;
        }
    }
}