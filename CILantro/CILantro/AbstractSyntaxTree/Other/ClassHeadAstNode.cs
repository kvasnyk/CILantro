using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("classHead")]
    public class ClassHeadAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _(".class") + classAttr + name1 + extendsClause + implClause
            var name1Children = AstChildren.Empty()
                .Add(".class")
                .Add<ClassAttrAstNode>()
                .Add<Name1AstNode>()
                .Add<ExtendsClauseAstNode>()
                .Add<ImplClauseAstNode>();
            if (name1Children.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            throw new NotImplementedException();
        }
    }
}