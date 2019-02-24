using CILantro.ProgramStructure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("customAttrDecl")]
    public class CustomAttrDeclAstNode : AstNodeBase
    {
        public CilCustomType CustomType { get; private set; }

        // TODO: what's this?
        public byte[] Bytes { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // customHead + bytes + _(")")
            var customHeadChildren = AstChildren.Empty()
                .Add<CustomHeadAstNode>()
                .Add<BytesAstNode>()
                .Add(")");
            if (customHeadChildren.PopulateWith(parseNode))
            {
                CustomType = customHeadChildren.Child1.CustomType;
                Bytes = customHeadChildren.Child2.Value;

                return;
            }

            throw new NotImplementedException();
        }
    }
}