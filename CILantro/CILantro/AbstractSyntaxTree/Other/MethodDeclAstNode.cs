using CILantro.Instructions;
using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;
using System.Collections.Generic;

namespace CILantro.AbstractSyntaxTree.Other
{
    public enum MethodDeclType
    {
        EntryPoint,
        Instruction,
        Label,
        MaxStack,
        CustomAttr,
        Locals
    }

    [AstNode("methodDecl")]
    public class MethodDeclAstNode : AstNodeBase
    {
        public MethodDeclType? DeclType { get; private set; }

        public CilInstruction Instruction { get; private set; }

        public List<CilSigArg> LocalsSigArgs { get; private set; }

        public string Label { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _(".maxstack") + int32
            var maxstackChildren = AstChildren.Empty()
                .Add(".maxstack")
                .Add<Int32AstNode>();
            if (maxstackChildren.PopulateWith(parseNode))
            {
                DeclType = MethodDeclType.MaxStack;

                return;
            }

            // _(".entrypoint")
            var entrypointChildren = AstChildren.Empty()
                .Add(".entrypoint");
            if (entrypointChildren.PopulateWith(parseNode))
            {
                DeclType = MethodDeclType.EntryPoint;

                return;
            }

            // instr
            var instrChildren = AstChildren.Empty()
                .Add<InstrAstNode>();
            if (instrChildren.PopulateWith(parseNode))
            {
                DeclType = MethodDeclType.Instruction;
                Instruction = instrChildren.Child1.Instruction;

                return;
            }

            // id + _(":")
            var idChildren = AstChildren.Empty()
                .Add<IdAstNode>()
                .Add(":");
            if (idChildren.PopulateWith(parseNode))
            {
                DeclType = MethodDeclType.Label;
                Label = idChildren.Child1.Value;

                return;
            }

            // customAttrDecl
            var customAttrChildren = AstChildren.Empty()
                .Add<CustomAttrDeclAstNode>();
            if (customAttrChildren.PopulateWith(parseNode))
            {
                DeclType = MethodDeclType.CustomAttr;

                return;
            }

            // localsHead + _("init") + _("(") + sigArgs0 + _(")")
            var localsInitChildren = AstChildren.Empty()
                .Add<LocalsHeadAstNode>()
                .Add("init")
                .Add("(")
                .Add<SigArgs0AstNode>()
                .Add(")");
            if (localsInitChildren.PopulateWith(parseNode))
            {
                DeclType = MethodDeclType.Locals;
                LocalsSigArgs = localsInitChildren.Child4.SigArgs;

                return;
            }

            throw new NotImplementedException();
        }
    }
}