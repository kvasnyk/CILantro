﻿using CILantro.Instructions;
using CILantro.Instructions.Method;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.InstuctionTypes
{
    [AstNode("INSTR_METHOD")]
    public class INSTR_METHODAstNode : AstNodeBase
    {
        public CilInstructionMethod Instruction { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _("call")
            var callChildren = AstChildren.Empty()
                .Add("call");
            if (callChildren.PopulateWith(parseNode))
            {
                Instruction = new CallInstruction();

                return;
            }

            // _("callvirt")
            var callvirtChildren = AstChildren.Empty()
                .Add("callvirt");
            if (callvirtChildren.PopulateWith(parseNode))
            {
                Instruction = new CallVirtualInstruction();

                return;
            }

            // _("newobj")
            var newobjChildren = AstChildren.Empty()
                .Add("newobj");
            if (newobjChildren.PopulateWith(parseNode))
            {
                Instruction = new NewObjectInstruction();

                return;
            }

            throw new NotImplementedException();
        }
    }
}