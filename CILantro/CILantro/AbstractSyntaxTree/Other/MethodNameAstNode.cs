using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("methodName")]
    public class MethodNameAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _(".ctor")
            var ctorChildren = AstChildren.Empty()
                .Add(".ctor");
            if (ctorChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // name1
            var name1Children = AstChildren.Empty()
                .Add<Name1AstNode>();
            if (name1Children.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            throw new NotImplementedException();
        }
    }
}