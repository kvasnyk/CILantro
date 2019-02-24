using CILantro.Exceptions;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("assemblyDecls")]
    public class AssemblyDeclsAstNode : AstNodeBase
    {
        // TODO: handle
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            var children0 = AstChildren.Empty();
            if (children0.PopulateWith(parseNode))
            {
                return;
            }

            // assemblyDecls + assemblyDecl
            var children2 = AstChildren.Empty()
                .Add<AssemblyDeclsAstNode>()
                .Add<AssemblyDeclAstNode>();
            if (children2.PopulateWith(parseNode))
            {
                return;
            }

            throw new InitAstNodeException(nameof(AssemblyDeclsAstNode));
        }
    }
}