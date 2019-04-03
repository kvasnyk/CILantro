using CILantro.Exceptions;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("classHead")]
    public class ClassHeadAstNode : AstNodeBase
    {
        public string ClassName { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _(".class") + classAttr + id + extendsClause + implClause
            var idChildren = AstChildren.Empty()
                .Add(".class")
                .Add<ClassAttrAstNode>()
                .Add<IdAstNode>()
                .Add<ExtendsClauseAstNode>()
                .Add<ImplClauseAstNode>();
            if (idChildren.PopulateWith(parseNode))
            {
                ClassName = idChildren.Child3.Value;

                return;
            }

            // _(".class") + classAttr + name1 + extendsClause + implClause
            var name1Children = AstChildren.Empty()
                .Add(".class")
                .Add<ClassAttrAstNode>()
                .Add<Name1AstNode>()
                .Add<ExtendsClauseAstNode>()
                .Add<ImplClauseAstNode>();
            if (name1Children.PopulateWith(parseNode))
            {
                ClassName = name1Children.Child3.Value;

                return;
            }

            throw new InitAstNodeException(nameof(ClassHeadAstNode));
        }
    }
}