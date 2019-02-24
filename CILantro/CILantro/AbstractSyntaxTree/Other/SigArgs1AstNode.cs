using CILantro.ProgramStructure;
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

            throw new NotImplementedException();
        }
    }
}