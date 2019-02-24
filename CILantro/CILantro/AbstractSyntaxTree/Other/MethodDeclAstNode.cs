using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("methodDecl")]
    public class MethodDeclAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _(".maxstack") + int32
            var maxstackChildren = AstChildren.Empty()
                .Add(".maxstack")
                .Add<Int32AstNode>();
            if (maxstackChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // _(".entrypoint")
            var entrypointChildren = AstChildren.Empty()
                .Add(".entrypoint");
            if (entrypointChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // instr
            var instrChildren = AstChildren.Empty()
                .Add<InstrAstNode>();
            if (instrChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // id + _(":")
            var idChildren = AstChildren.Empty()
                .Add<IdAstNode>()
                .Add(":");
            if (idChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            throw new NotImplementedException();
        }
    }
}