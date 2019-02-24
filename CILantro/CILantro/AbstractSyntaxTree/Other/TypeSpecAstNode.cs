using CILantro.Model;
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
                TypeSpec = new CilTypeSpec(classNameChildren.Child1.ClassName);

                return;
            }

            throw new NotImplementedException();
        }
    }
}