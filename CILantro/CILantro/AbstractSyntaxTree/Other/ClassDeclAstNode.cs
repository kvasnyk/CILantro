using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    public enum ClassDeclType
    {
        Method
    }

    [AstNode("classDecl")]
    public class ClassDeclAstNode : AstNodeBase
    {
        public ClassDeclType? DeclType { get; private set; }

        public CilMethod Method { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // methodHead + methodDecls + _("}")
            var methodChildren = AstChildren.Empty()
                .Add<MethodHeadAstNode>()
                .Add<MethodDeclsAstNode>()
                .Add("}");
            if (methodChildren.PopulateWith(parseNode))
            {
                DeclType = ClassDeclType.Method;
                Method = new CilMethod
                {
                    Name = methodChildren.Child1.MethodName,
                    EntryPoints = methodChildren.Child2.MethodDecls.EntryPoints,
                    Instructions = methodChildren.Child2.MethodDecls.Instructions
                };

                return;
            }

            throw new NotImplementedException();
        }
    }
}