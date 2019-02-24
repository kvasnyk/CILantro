using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("moduleHead")]
    public class ModuleHeadAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _(".module") + name1
            var name1Children = AstChildren.Empty()
                .Add(".module")
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