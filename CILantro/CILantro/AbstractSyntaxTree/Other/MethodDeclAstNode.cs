using CILantro.Instructions;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    public enum MethodDeclType
    {
        EntryPoint,
        Instruction,
        Label,
        MaxStack,
        CustomAttr
    }

    [AstNode("methodDecl")]
    public class MethodDeclAstNode : AstNodeBase
    {
        public MethodDeclType? DeclType { get; private set; }

        public CilInstruction Instruction { get; private set; }

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

            throw new NotImplementedException();
        }
    }
}