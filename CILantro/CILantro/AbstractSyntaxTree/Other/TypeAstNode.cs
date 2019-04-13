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
                Type = new CilTypeString();

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

            // _("float64")
            var float64Children = AstChildren.Empty()
                .Add("float64");
            if (float64Children.PopulateWith(parseNode))
            {
                Type = new CilTypeSimple
                {
                    Kind = CilSimpleTypeKind.Float64
                };

                return;
            }

            // _("float32")
            var float32Children = AstChildren.Empty()
                .Add("float32");
            if (float32Children.PopulateWith(parseNode))
            {
                Type = new CilTypeSimple
                {
                    Kind = CilSimpleTypeKind.Float32
                };

                return;
            }

            // _("int64")
            var int64Children = AstChildren.Empty()
                .Add("int64");
            if (int64Children.PopulateWith(parseNode))
            {
                Type = new CilTypeSimple
                {
                    Kind = CilSimpleTypeKind.Int64
                };

                return;
            }

            // _("int8")
            var int8Children = AstChildren.Empty()
                .Add("int8");
            if (int8Children.PopulateWith(parseNode))
            {
                Type = new CilTypeSimple
                {
                    Kind = CilSimpleTypeKind.Int8
                };

                return;
            }

            // _("uint16")
            var uint16Children = AstChildren.Empty()
                .Add("uint16");
            if (uint16Children.PopulateWith(parseNode))
            {
                Type = new CilTypeSimple
                {
                    Kind = CilSimpleTypeKind.UInt16
                };

                return;
            }

            // _("uint64")
            var uint64Children = AstChildren.Empty()
                .Add("uint64");
            if (uint64Children.PopulateWith(parseNode))
            {
                Type = new CilTypeSimple
                {
                    Kind = CilSimpleTypeKind.UInt64
                };

                return;
            }

            // _("uint32")
            var uint32Children = AstChildren.Empty()
                .Add("uint32");
            if (uint32Children.PopulateWith(parseNode))
            {
                Type = new CilTypeSimple
                {
                    Kind = CilSimpleTypeKind.UInt32
                };

                return;
            }

            // _("int16")
            var int16Children = AstChildren.Empty()
                .Add("int16");
            if (int16Children.PopulateWith(parseNode))
            {
                Type = new CilTypeSimple
                {
                    Kind = CilSimpleTypeKind.Int16
                };

                return;
            }

            throw new NotImplementedException();
        }
    }
}