using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;
using System.Collections.Generic;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("classNames")]
    public class ClassNamesAstNode : AstNodeBase
    {
        public List<CilClassName> ClassNames { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // className
            var classNameChildren = AstChildren.Empty()
                .Add<ClassNameAstNode>();
            if (classNameChildren.PopulateWith(parseNode))
            {
                ClassNames = new List<CilClassName> { classNameChildren.Child1.ClassName };

                return;
            }

            throw new NotImplementedException();
        }
    }
}