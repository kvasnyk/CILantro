using CILantro.Interpreting.Types;
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
                var elementType = typeArrayChildren.Child1.Type;

                Type = new CilTypeArray(elementType);

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
                Type = new CilTypeBool();

                return;
            }

            // _("int32")
            var int32Children = AstChildren.Empty()
                .Add("int32");
            if (int32Children.PopulateWith(parseNode))
            {
                Type = new CilTypeInt32();

                return;
            }

            // _("valuetype") + className
            var valueTypeClassNameChildren = AstChildren.Empty()
                .Add("valuetype")
                .Add<ClassNameAstNode>();
            if (valueTypeClassNameChildren.PopulateWith(parseNode))
            {
                var className = valueTypeClassNameChildren.Child2.ClassName;
                Type = new CilTypeValueType(className);

                return;
            }

            // _("uint8")
            var uint8Children = AstChildren.Empty()
                .Add("uint8");
            if (uint8Children.PopulateWith(parseNode))
            {
                Type = new CilTypeUInt8();

                return;
            }

            // _("char")
            var charChildren = AstChildren.Empty()
                .Add("char");
            if (charChildren.PopulateWith(parseNode))
            {
                Type = new CilTypeChar();

                return;
            }

            // _("float64")
            var float64Children = AstChildren.Empty()
                .Add("float64");
            if (float64Children.PopulateWith(parseNode))
            {
                Type = new CilTypeFloat64();

                return;
            }

            // _("float32")
            var float32Children = AstChildren.Empty()
                .Add("float32");
            if (float32Children.PopulateWith(parseNode))
            {
                Type = new CilTypeFloat32();

                return;
            }

            // _("int64")
            var int64Children = AstChildren.Empty()
                .Add("int64");
            if (int64Children.PopulateWith(parseNode))
            {
                Type = new CilTypeInt64();

                return;
            }

            // _("int8")
            var int8Children = AstChildren.Empty()
                .Add("int8");
            if (int8Children.PopulateWith(parseNode))
            {
                Type = new CilTypeInt8();

                return;
            }

            // _("uint16")
            var uint16Children = AstChildren.Empty()
                .Add("uint16");
            if (uint16Children.PopulateWith(parseNode))
            {
                Type = new CilTypeUInt16();

                return;
            }

            // _("uint64")
            var uint64Children = AstChildren.Empty()
                .Add("uint64");
            if (uint64Children.PopulateWith(parseNode))
            {
                Type = new CilTypeUInt64();

                return;
            }

            // _("uint32")
            var uint32Children = AstChildren.Empty()
                .Add("uint32");
            if (uint32Children.PopulateWith(parseNode))
            {
                Type = new CilTypeUInt32();

                return;
            }

            // _("int16")
            var int16Children = AstChildren.Empty()
                .Add("int16");
            if (int16Children.PopulateWith(parseNode))
            {
                Type = new CilTypeInt16();

                return;
            }

            // _("object")
            var objectChildren = AstChildren.Empty()
                .Add("object");
            if (objectChildren.PopulateWith(parseNode))
            {
                Type = new CilTypeObject();

                return;
            }

            // _("class") + className
            var classChildren = AstChildren.Empty()
                .Add("class")
                .Add<ClassNameAstNode>();
            if (classChildren.PopulateWith(parseNode))
            {
                var className = classChildren.Child2.ClassName;
                Type = new CilTypeClass(className);

                return;
            }

            throw new NotImplementedException();
        }
    }
}