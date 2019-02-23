using CILantro.Extensions;
using CILantro.Model;
using Irony.Ast;
using Irony.Parsing;
using System;
using System.Collections.Generic;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("asmAttr")]
    public class AsmAttrAstNode : AstNodeBase
    {
        public List<CilAssemblyAttribute> Attributes { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            if (parseNode.ChildNodes.IsEmpty())
            {
                Attributes = new List<CilAssemblyAttribute>();

                return;
            }

            throw new NotImplementedException();
        }
    }
}