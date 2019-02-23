using CILantro.Extensions;
using CILantro.Model;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    public enum AsmOrRefDeclType
    {
        Ver
    }

    [AstNode("asmOrRefDecl")]
    public class AsmOrRefDeclAstNode : AstNodeBase
    {
        public AsmOrRefDeclType? DeclType { get; private set; }

        public CilAssemblyVersion Version { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            var int32Nodes = parseNode.FindChildrenArray<Int32AstNode>();

            // _(".ver") + int32 + _(":") + int32 + _(":") + int32 + _(":") + int32
            if (int32Nodes.Length == 4)
            {
                DeclType = AsmOrRefDeclType.Ver;
                Version = new CilAssemblyVersion(int32Nodes[0].Value, int32Nodes[1].Value, int32Nodes[2].Value, int32Nodes[3].Value);

                return;
            }

            throw new NotImplementedException();
        }
    }
}