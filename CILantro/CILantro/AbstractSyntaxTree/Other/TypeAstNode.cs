using CILantro.ProgramStructure;
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
                Type = new CilType(CilTypeType.String);

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
                Type = new CilType(CilTypeType.Void);

                return;
            }

            // _("bool")
            var boolChildren = AstChildren.Empty()
                .Add("bool");
            if (boolChildren.PopulateWith(parseNode))
            {
                Type = new CilType(CilTypeType.Bool);

                return;
            }

            // _("int32")
            var int32Children = AstChildren.Empty()
                .Add("int32");
            if (int32Children.PopulateWith(parseNode))
            {
                Type = new CilType(CilTypeType.Int32);

                return;
            }

            throw new NotImplementedException();
        }
    }
}