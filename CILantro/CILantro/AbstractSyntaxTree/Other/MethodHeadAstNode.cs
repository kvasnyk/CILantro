using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;
using System.Collections.Generic;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("methodHead")]
    public class MethodHeadAstNode : AstNodeBase
    {
        public string MethodName { get; private set; }

        public List<CilSigArg> Arguments { get; private set; }

        public CilCallConv CallConv { get; private set; }

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
                MethodName = shortChildren.Child6.MethodName;
                Arguments = shortChildren.Child8.SigArgs;
                CallConv = shortChildren.Child3.CallConv;

                return;
            }

            throw new NotImplementedException();
        }
    }
}