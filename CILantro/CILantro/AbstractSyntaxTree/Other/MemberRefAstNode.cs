using CILantro.Interpreting.Types;
using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("memberRef")]
    public class MemberRefAstNode : AstNodeBase
    {
        public CilType FieldType { get; private set; }

        public CilTypeSpec FieldTypeSpec { get; private set; }

        public string FieldId { get; private set; }

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
                FieldType = field5Children.Child2.Type;
                FieldTypeSpec = field5Children.Child3.TypeSpec;
                FieldId = field5Children.Child5.Value;

                return;
            }

            throw new NotImplementedException();
        }
    }
}