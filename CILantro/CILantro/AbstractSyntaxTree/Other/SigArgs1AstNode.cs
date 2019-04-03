using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;
using System.Collections.Generic;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("sigArgs1")]
    public class SigArgs1AstNode : AstNodeBase
    {
        public List<CilSigArg> SigArgs { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // sigArg
            var sigArgChildren = AstChildren.Empty()
                .Add<SigArgAstNode>();
            if (sigArgChildren.PopulateWith(parseNode))
            {
                SigArgs = new List<CilSigArg> { sigArgChildren.Child1.SigArg };

                return;
            }

            // sigArgs1 + _(",") + sigArg
            var sigArgs1Children = AstChildren.Empty()
                .Add<SigArgs1AstNode>()
                .Add(",")
                .Add<SigArgAstNode>();
            if (sigArgs1Children.PopulateWith(parseNode))
            {
                var sigArgs = sigArgs1Children.Child1.SigArgs;
                sigArgs.Add(sigArgs1Children.Child3.SigArg);

                SigArgs = sigArgs;

                return;
            }

            throw new NotImplementedException();
        }
    }
}