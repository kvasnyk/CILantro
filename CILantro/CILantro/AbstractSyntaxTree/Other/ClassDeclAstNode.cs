using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    public enum ClassDeclType
    {
        Method,
        CustomAttr
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
                    IsEntryPoint = methodChildren.Child2.MethodDecls.IsEntryPoint,
                    Instructions = methodChildren.Child2.MethodDecls.Instructions,
                    Locals = methodChildren.Child2.MethodDecls.Locals
                };

                return;
            }

            // customAttrDecl
            var customAttrChildren = AstChildren.Empty()
                .Add<CustomAttrDeclAstNode>();
            if (customAttrChildren.PopulateWith(parseNode))
            {
                DeclType = ClassDeclType.CustomAttr;
                // TODO: handle

                return;
            }

            throw new NotImplementedException();
        }
    }
}