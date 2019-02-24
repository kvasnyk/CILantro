using CILantro.Exceptions;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("methodDecls")]
    public class MethodDeclsAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            var emptyChildren = AstChildren.Empty();
            if (emptyChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // methodDecls + methodDecl
            var methodDeclsChildren = AstChildren.Empty()
                .Add<MethodDeclsAstNode>()
                .Add<MethodDeclAstNode>();
            if (methodDeclsChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            throw new InitAstNodeException(nameof(MethodDeclsAstNode));
        }
    }
}