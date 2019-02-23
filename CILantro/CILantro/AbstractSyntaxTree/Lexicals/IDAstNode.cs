using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Lexicals
{
    [AstNode("ID")]
    public class IDAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            throw new NotImplementedException();
        }
    }
}