using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("ownerType")]
    public class OwnerTypeAstNode : AstNodeBase
    {
        public CilTypeSpec TypeSpec { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // typeSpec
            var typeSpecChildren = AstChildren.Empty()
                .Add<TypeSpecAstNode>();
            if (typeSpecChildren.PopulateWith(parseNode))
            {
                TypeSpec = typeSpecChildren.Child1.TypeSpec;

                return;
            }

            throw new NotImplementedException();
        }
    }
}