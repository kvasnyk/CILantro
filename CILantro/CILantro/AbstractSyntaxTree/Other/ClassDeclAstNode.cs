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
        CustomAttr,
        Field,
        Pack,
        Size
    }

    [AstNode("classDecl")]
    public class ClassDeclAstNode : AstNodeBase
    {
        public ClassDeclType? DeclType { get; private set; }

        public CilMethod Method { get; private set; }

        public CilField Field { get; private set; }

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
                    Locals = methodChildren.Child2.MethodDecls.Locals,
                    Arguments = methodChildren.Child1.Arguments,
                    CallConv = methodChildren.Child1.CallConv,
                    ReturnType = methodChildren.Child1.ReturnType
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

            // fieldDecl
            var fieldDeclChildren = AstChildren.Empty()
                .Add<FieldDeclAstNode>();
            if (fieldDeclChildren.PopulateWith(parseNode))
            {
                DeclType = ClassDeclType.Field;
                Field = fieldDeclChildren.Child1.Field;

                return;
            }

            // _(".pack") + int32
            var packChildren = AstChildren.Empty()
                .Add(".pack")
                .Add<Int32AstNode>();
            if (packChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                DeclType = ClassDeclType.Pack;

                return;
            }

            // _(".size") + int32
            var sizeChildren = AstChildren.Empty()
                .Add(".size")
                .Add<Int32AstNode>();
            if (sizeChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                DeclType = ClassDeclType.Size;

                return;
            }

            throw new NotImplementedException();
        }
    }
}