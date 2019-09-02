using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("paramAttr")]
    public class ParamAttrAstNode : AstNodeBase
    {
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
                // TODO - handle
                return;
            }

            // paramAttr + _("[") + _("out") + _("]")
            var outChildren = AstChildren.Empty()
                .Add<ParamAttrAstNode>()
                .Add("[")
                .Add("out")
                .Add("]");
            if (outChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            // paramAttr + _("[") + _("opt") + _("]")
            var optChildren = AstChildren.Empty()
                .Add<ParamAttrAstNode>()
                .Add("[")
                .Add("opt")
                .Add("]");
            if (optChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            throw new NotImplementedException();
        }
    }
}