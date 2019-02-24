using CILantro.Exceptions;
using CILantro.ProgramStructure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System.Collections.Generic;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("sigArgs0")]
    public class SigArgs0AstNode : AstNodeBase
    {
        public List<CilSigArg> SigArgs { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            var emptyChildren = AstChildren.Empty();
            if (emptyChildren.PopulateWith(parseNode))
            {
                SigArgs = new List<CilSigArg>();

                return;
            }

            // sigArgs1
            var sigArgs1Children = AstChildren.Empty()
                .Add<SigArgs1AstNode>();
            if (sigArgs1Children.PopulateWith(parseNode))
            {
                SigArgs = sigArgs1Children.Child1.SigArgs;

                return;
            }

            throw new InitAstNodeException(nameof(SigArgs0AstNode));
        }
    }
}