using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("tls")]
    public class TlsAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            throw new NotImplementedException();
        }
    }
}