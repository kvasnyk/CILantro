using CILantro.Exceptions;
using CILantro.Extensions;
using CILantro.Model;
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
            var asmAttrNode = parseNode.FindChild<AsmAttrAstNode>();
            var name1Node = parseNode.FindChild<Name1AstNode>();

            // _(".assembly") + asmAttr + name1
            if (asmAttrNode != null && name1Node != null)
            {
                AssemblyName = name1Node.Value;
                AssemblyAttributes = asmAttrNode.Attributes;

                return;
            }

            throw new InitAstNodeException(nameof(AssemblyHeadAstNode));
        }
    }
}