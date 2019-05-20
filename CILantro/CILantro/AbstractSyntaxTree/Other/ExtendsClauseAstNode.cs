using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("extendsClause")]
    public class ExtendsClauseAstNode : AstNodeBase
    {
        public CilClassName ClassName { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _("extends") + className
            var extendsChildren = AstChildren.Empty()
                .Add("extends")
                .Add<ClassNameAstNode>();
            if (extendsChildren.PopulateWith(parseNode))
            {
                ClassName = extendsChildren.Child2.ClassName;

                return;
            }

            throw new NotImplementedException();
        }
    }
}