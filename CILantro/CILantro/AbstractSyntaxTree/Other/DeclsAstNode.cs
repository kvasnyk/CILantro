using CILantro.Model;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("decls")]
    public class DeclsAstNode : AstNodeBase
    {
        public CilProgram Program { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            throw new NotImplementedException();
        }
    }
}