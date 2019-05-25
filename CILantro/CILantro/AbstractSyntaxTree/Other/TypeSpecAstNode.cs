using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("typeSpec")]
    public class TypeSpecAstNode : AstNodeBase
    {
        public CilTypeSpec TypeSpec { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // className
            var classNameChildren = AstChildren.Empty()
                .Add<ClassNameAstNode>();
            if (classNameChildren.PopulateWith(parseNode))
            {
                TypeSpec = new CilTypeSpec
                {
                    ClassName = classNameChildren.Child1.ClassName
                };

                return;
            }

            // type
            var typeChildren = AstChildren.Empty()
                .Add<TypeAstNode>();
            if (typeChildren.PopulateWith(parseNode))
            {
                TypeSpec = new CilTypeSpec
                {
                    Type = typeChildren.Child1.Type
                };

                return;
            }

            throw new NotImplementedException();
        }
    }
}