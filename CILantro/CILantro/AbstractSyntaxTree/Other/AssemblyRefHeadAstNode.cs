using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("assemblyRefHead")]
    public class AssemblyRefHeadAstNode : AstNodeBase
    {
        public string AssemblyName { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // ___(".assembly") + _("extern") + name1
            var children3 = AstChildren.Empty()
                .Add(".assembly")
                .Add("extern")
                .Add<Name1AstNode>();
            if (children3.PopulateWith(parseNode))
            {
                AssemblyName = children3.Child3.Value;

                return;
            }

            throw new NotImplementedException();
        }
    }
}