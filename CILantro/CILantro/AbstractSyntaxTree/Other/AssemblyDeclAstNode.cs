using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("assemblyDecl")]
    public class AssemblyDeclAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _(".hash") + _("algorithm") + int32
            var hashChildren = AstChildren.Empty()
                .Add(".hash")
                .Add("algorithm")
                .Add<Int32AstNode>();
            if (hashChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // asmOrRefDecl
            var asmOrRefDeclChildren = AstChildren.Empty()
                .Add<AsmOrRefDeclAstNode>();
            if (asmOrRefDeclChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            throw new NotImplementedException();
        }
    }
}