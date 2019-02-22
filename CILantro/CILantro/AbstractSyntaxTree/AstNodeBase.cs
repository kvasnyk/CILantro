using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree
{
    public abstract class AstNodeBase : IAstNodeInit
    {
        public abstract void Init(AstContext context, ParseTreeNode parseNode);
    }
}