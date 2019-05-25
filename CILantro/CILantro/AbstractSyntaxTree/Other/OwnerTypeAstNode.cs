using CILantro.Interpreting.Types;
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

        public CilType FieldType { get; private set; }

        public CilTypeSpec FieldTypeSpec { get; private set; }

        public string FieldId { get; private set; }

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

            // memberRef
            var memberRefChildren = AstChildren.Empty()
                .Add<MemberRefAstNode>();
            if (memberRefChildren.PopulateWith(parseNode))
            {
                FieldType = memberRefChildren.Child1.FieldType;
                FieldTypeSpec = memberRefChildren.Child1.FieldTypeSpec;
                FieldId = memberRefChildren.Child1.FieldId;

                return;
            }

            throw new NotImplementedException();
        }
    }
}