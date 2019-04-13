using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("paramAttr")]
    public class ParamAttrAstNode : AstNodeBase
    {
        // TODO: what should we store here?

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            var emptyChildren = AstChildren.Empty();
            if (emptyChildren.PopulateWith(parseNode))
            {
                return;
            }

            // paramAttr + _("[") + int32 + _("]")
            var int32Children = AstChildren.Empty()
                .Add<ParamAttrAstNode>()
                .Add("[")
                .Add<Int32AstNode>()
                .Add("]");
            if (int32Children.PopulateWith(parseNode))
            {
                // TODO: handle

                return;
            }

            throw new NotImplementedException();
        }
    }
}