using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("secDecl")]
    public class SecDeclAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _(".permissionset") + secAction + _("=") + _("{") + nameValPairs + _("}")
            var permissionSetChildren = AstChildren.Empty()
                .Add(".permissionset")
                .Add<SecActionAstNode>()
                .Add("=")
                .Add("{")
                .Add<NameValPairsAstNode>()
                .Add("}");
            if (permissionSetChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            throw new NotImplementedException();
        }
    }
}