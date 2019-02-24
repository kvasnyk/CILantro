using CILantro.Exceptions;
using CILantro.Model;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System.Collections.Generic;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("assemblyHead")]
    public class AssemblyHeadAstNode : AstNodeBase
    {
        public string AssemblyName { get; private set; }

        public List<CilAssemblyAttribute> AssemblyAttributes { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _(".assembly") + asmAttr + name1
            var children3 = AstChildren.Empty()
                .Add(".assembly")
                .Add<AsmAttrAstNode>()
                .Add<Name1AstNode>();
            if (children3.PopulateWith(parseNode))
            {
                AssemblyName = children3.Child3.Value;
                AssemblyAttributes = children3.Child2.Attributes;

                return;
            }

            throw new InitAstNodeException(nameof(AssemblyHeadAstNode));
        }
    }
}