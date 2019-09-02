using CILantro.Interpreting.Values;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("initOpt")]
    public class InitOptAstNode : AstNodeBase
    {
        public IValue InitValue { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            var emptyChildren = AstChildren.Empty();
            if (emptyChildren.PopulateWith(parseNode))
            {
                // TODO - handle
                return;
            }

            // _("=") + fieldInit
            var fieldInitChildren = AstChildren.Empty()
                .Add("=")
                .Add<FieldInitAstNode>();
            if (fieldInitChildren.PopulateWith(parseNode))
            {
                InitValue = fieldInitChildren.Child2.InitValue;

                return;
            }

            throw new NotImplementedException();
        }
    }
}