using CILantro.Exceptions;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("classDecls")]
    public class ClassDeclsAstNode : AstNodeBase
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

            // classDecls + classDecl
            var classDeclsChildren = AstChildren.Empty()
                .Add<ClassDeclsAstNode>()
                .Add<ClassDeclAstNode>();
            if (classDeclsChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            throw new InitAstNodeException(nameof(ClassDeclsAstNode));
        }
    }
}