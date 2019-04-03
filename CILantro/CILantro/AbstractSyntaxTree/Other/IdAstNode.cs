using CILantro.AbstractSyntaxTree.Lexicals;
using CILantro.Exceptions;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("id")]
    public class IdAstNode : AstNodeBase
    {
        public string Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // ID
            var IDChildren = AstChildren.Empty()
                .Add<IDAstNode>();
            if (IDChildren.PopulateWith(parseNode))
            {
                Value = IDChildren.Child1.Value;

                return;
            }

            // SQSTRING
            var SQSTRINGChildren = AstChildren.Empty()
                .Add<SQSTRINGAstNode>();
            if (SQSTRINGChildren.PopulateWith(parseNode))
            {
                Value = SQSTRINGChildren.Child1.Value;

                return;
            }

            throw new InitAstNodeException(nameof(IdAstNode));
        }
    }
}