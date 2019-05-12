using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("methodName")]
    public class MethodNameAstNode : AstNodeBase
    {
        public string MethodName { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _(".ctor")
            var ctorChildren = AstChildren.Empty()
                .Add(".ctor");
            if (ctorChildren.PopulateWith(parseNode))
            {
                MethodName = ".ctor";

                return;
            }

            // name1
            var name1Children = AstChildren.Empty()
                .Add<Name1AstNode>();
            if (name1Children.PopulateWith(parseNode))
            {
                MethodName = name1Children.Child1.Value;

                return;
            }

            // _(".cctor")
            var cctorChildren = AstChildren.Empty()
                .Add(".cctor");
            if (cctorChildren.PopulateWith(parseNode))
            {
                MethodName = ".cctor";

                return;
            }

            throw new NotImplementedException();
        }
    }
}