using CILantro.Exceptions;
using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System.Collections.Generic;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("classDecls")]
    public class ClassDeclsAstNode : AstNodeBase
    {
        public CilClassDecls ClassDecls { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            var emptyChildren = AstChildren.Empty();
            if (emptyChildren.PopulateWith(parseNode))
            {
                ClassDecls = new CilClassDecls
                {
                    Methods = new List<CilMethod>()
                };

                return;
            }

            // classDecls + classDecl
            var classDeclsChildren = AstChildren.Empty()
                .Add<ClassDeclsAstNode>()
                .Add<ClassDeclAstNode>();
            if (classDeclsChildren.PopulateWith(parseNode))
            {
                ClassDecls = classDeclsChildren.Child1.ClassDecls;

                var declType = classDeclsChildren.Child2.DeclType;
                   
                if (!declType.HasValue)
                    throw new AstNodeException($"\"{nameof(declType)}\" is not specified.");

                switch (declType)
                {
                    case ClassDeclType.Method:
                        ClassDecls.Methods.Add(classDeclsChildren.Child2.Method);
                        break;
                    case ClassDeclType.CustomAttr:
                        // TODO: handle
                        break;
                    default:
                        throw new AstNodeException($"\"{nameof(declType)}\" cannot be recognized.");
                }

                return;
            }

            throw new InitAstNodeException(nameof(ClassDeclsAstNode));
        }
    }
}