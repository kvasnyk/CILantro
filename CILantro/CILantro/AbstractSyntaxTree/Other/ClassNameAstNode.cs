using CILantro.PorgramStructure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("className")]
    public class ClassNameAstNode : AstNodeBase
    {
        public CilClassName ClassName { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _("[") + name1 + _("]") + slashedName
            var children4 = AstChildren.Empty()
                .Add("[")
                .Add<Name1AstNode>()
                .Add("]")
                .Add<SlashedNameAstNode>();
            if (children4.PopulateWith(parseNode))
            {
                ClassName = new CilClassName(children4.Child4.Value, children4.Child2.Value);

                return;
            }

            throw new NotImplementedException();
        }
    }
}