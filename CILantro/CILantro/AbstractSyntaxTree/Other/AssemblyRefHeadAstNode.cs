using CILantro.Extensions;
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
            if (parseNode.ChildNodes.Count == 3)
            {
                var name1Node = parseNode.FindChild<Name1AstNode>();
                AssemblyName = name1Node.Value;

                return;
            }

            throw new NotImplementedException();
        }
    }
}