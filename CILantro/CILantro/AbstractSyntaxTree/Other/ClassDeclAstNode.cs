using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("classDecl")]
    public class ClassDeclAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // methodHead + methodDecls + _("}")
            var methodChildren = AstChildren.Empty()
                .Add<MethodHeadAstNode>()
                .Add<MethodDeclsAstNode>()
                .Add("}");
            if (methodChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            throw new NotImplementedException();
        }
    }
}