using CILantro.PorgramStructure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("customType")]
    public class CustomTypeAstNode : AstNodeBase
    {
        public CilCustomType CustomType { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // callConv + type + typeSpec + _("::") + _(".ctor") + _("(") + sigArgs0 + _(")")
            var typeSpecChildren = AstChildren.Empty()
                .Add<CallConvAstNode>()
                .Add<TypeAstNode>()
                .Add<TypeSpecAstNode>()
                .Add("::")
                .Add(".ctor")
                .Add("(")
                .Add<SigArgs0AstNode>()
                .Add(")");
            if (typeSpecChildren.PopulateWith(parseNode))
            {
                CustomType = new CilCustomType(typeSpecChildren.Child1.CallConv, typeSpecChildren.Child2.Type, typeSpecChildren.Child3.TypeSpec, typeSpecChildren.Child7.SigArgs);

                return;
            }

            throw new NotImplementedException();
        }
    }
}