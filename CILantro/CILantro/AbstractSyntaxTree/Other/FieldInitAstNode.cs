using CILantro.Interpreting.Values;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("fieldInit")]
    public class FieldInitAstNode : AstNodeBase
    {
        public IValue InitValue { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _("int32") + _("(") + int64 + _(")")
            var int32Children = AstChildren.Empty()
                .Add("int32")
                .Add("(")
                .Add<Int64AstNode>()
                .Add(")");
            if (int32Children.PopulateWith(parseNode))
            {
                InitValue = new CilValueInt32((int)int32Children.Child3.Value);

                return;
            }

            // _("int16") + _("(") + int64 + _(")")
            var int16Children = AstChildren.Empty()
                .Add("int16")
                .Add("(")
                .Add<Int64AstNode>()
                .Add(")");
            if (int16Children.PopulateWith(parseNode))
            {
                InitValue = new CilValueInt16((short)int16Children.Child3.Value);

                return;
            }

            // _("int64") + _("(") + int64 + _(")")
            var int64Children = AstChildren.Empty()
                .Add("int64")
                .Add("(")
                .Add<Int64AstNode>()
                .Add(")");
            if (int64Children.PopulateWith(parseNode))
            {
                InitValue = new CilValueInt64(int64Children.Child3.Value);

                return;
            }

            // _("uint8") + _("(") + int64 + _(")")
            var uint8Children = AstChildren.Empty()
                .Add("uint8")
                .Add("(")
                .Add<Int64AstNode>()
                .Add(")");
            if (uint8Children.PopulateWith(parseNode))
            {
                InitValue = new CilValueUInt8((byte)uint8Children.Child3.Value);

                return;
            }

            throw new NotImplementedException();
        }
    }
}