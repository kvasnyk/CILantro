using CILantro.Extensions;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("assemblyDecls")]
    public class AssemblyDeclsAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            if (parseNode.ChildNodes.IsEmpty())
            {
                return;
            }

            throw new NotImplementedException();
        }
    }
}