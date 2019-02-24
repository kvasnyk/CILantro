using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("methodHead")]
    public class MethodHeadAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // methodHeadPart1 + methAttr + callConv + paramAttr + type + methodName + _("(") + sigArgs0 + _(")") + implAttr + _("{")
            var shortChildren = AstChildren.Empty()
                .Add<MethodHeadPart1AstNode>()
                .Add<MethAttrAstNode>()
                .Add<CallConvAstNode>()
                .Add<ParamAttrAstNode>()
                .Add<TypeAstNode>()
                .Add<MethodNameAstNode>()
                .Add("(")
                .Add<SigArgs0AstNode>()
                .Add(")")
                .Add<ImplAttrAstNode>()
                .Add("{");
            if (shortChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            throw new NotImplementedException();
        }
    }
}