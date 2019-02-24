using CILantro.Model;
using CILantro.Utils;
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
            var emptyChildren = AstChildren.Empty();
            if (emptyChildren.PopulateWith(parseNode))
            {
                Attributes = new List<CilAssemblyAttribute>();

                return;
            }

            throw new NotImplementedException();
        }
    }
}