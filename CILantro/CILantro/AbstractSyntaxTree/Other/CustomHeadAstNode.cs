using CILantro.Exceptions;
using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("customHead")]
    public class CustomHeadAstNode : AstNodeBase
    {
        public CilCustomType CustomType { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _(".custom") + customType + _("=") + _("(")
            var children = AstChildren.Empty()
                .Add(".custom")
                .Add<CustomTypeAstNode>()
                .Add("=")
                .Add("(");
            if (children.PopulateWith(parseNode))
            {
                CustomType = children.Child2.CustomType;

                return;
            }

            throw new InitAstNodeException(nameof(CustomHeadAstNode));
        }
    }
}