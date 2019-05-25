using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("ddItem")]
    public class DdItemAstNode : AstNodeBase
    {
        public CilDataItem DataItem { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // bytearrayhead + bytes + _(")")
            var bytearrayChildren = AstChildren.Empty()
                .Add<BytearrayheadAstNode>()
                .Add<BytesAstNode>()
                .Add(")");
            if (bytearrayChildren.PopulateWith(parseNode))
            {
                DataItem = new CilDataItem
                {
                    ByteArray = bytearrayChildren.Child2.Value
                };

                return;
            }

            throw new NotImplementedException();
        }
    }
}