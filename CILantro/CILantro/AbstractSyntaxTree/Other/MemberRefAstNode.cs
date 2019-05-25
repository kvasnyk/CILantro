using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("memberRef")]
    public class MemberRefAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _("field") + type + typeSpec + _("::") + id
            var field5Children = AstChildren.Empty()
                .Add("field")
                .Add<TypeAstNode>()
                .Add<TypeSpecAstNode>()
                .Add("::")
                .Add<IdAstNode>();
            if (field5Children.PopulateWith(parseNode))
            {
                // TODO: handle

                return;
            }

            throw new NotImplementedException();
        }
    }
}