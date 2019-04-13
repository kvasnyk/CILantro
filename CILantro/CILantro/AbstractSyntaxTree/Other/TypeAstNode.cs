using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("type")]
    public class TypeAstNode : AstNodeBase
    {
        public CilType Type { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _("string")
            var stringChildren = AstChildren.Empty()
                .Add("string");
            if (stringChildren.PopulateWith(parseNode))
            {
                Type = new CilTypeSimple
                {
                    Kind = CilSimpleTypeKind.String
                };

                return;
            }

            // type + _("[") + _("]")
            var typeArrayChildren = AstChildren.Empty()
                .Add<TypeAstNode>()
                .Add("[")
                .Add("]");
            if (typeArrayChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // _("void")
            var voidChildren = AstChildren.Empty()
                .Add("void");
            if (voidChildren.PopulateWith(parseNode))
            {
                Type = new CilTypeVoid();

                return;
            }

            // _("bool")
            var boolChildren = AstChildren.Empty()
                .Add("bool");
            if (boolChildren.PopulateWith(parseNode))
            {
                Type = new CilTypeSimple
                {
                    Kind = CilSimpleTypeKind.Bool
                };

                return;
            }

            // _("int32")
            var int32Children = AstChildren.Empty()
                .Add("int32");
            if (int32Children.PopulateWith(parseNode))
            {
                Type = new CilTypeSimple
                {
                    Kind = CilSimpleTypeKind.Int32
                };

                return;
            }

            // _("valuetype") + className
            var valueTypeClassNameChildren = AstChildren.Empty()
                .Add("valuetype")
                .Add<ClassNameAstNode>();
            if (valueTypeClassNameChildren.PopulateWith(parseNode))
            {
                Type = new CilTypeValue
                {
                    ClassName = valueTypeClassNameChildren.Child2.ClassName
                };

                return;
            }

            // _("uint8")
            var uint8Children = AstChildren.Empty()
                .Add("uint8");
            if (uint8Children.PopulateWith(parseNode))
            {
                Type = new CilTypeSimple
                {
                    Kind = CilSimpleTypeKind.UInt8
                };

                return;
            }

            // _("char")
            var charChildren = AstChildren.Empty()
                .Add("char");
            if (charChildren.PopulateWith(parseNode))
            {
                Type = new CilTypeSimple
                {
                    Kind = CilSimpleTypeKind.Char
                };

                return;
            }

            throw new NotImplementedException();
        }
    }
}