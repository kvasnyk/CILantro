using CILantro.Instructions;
using CILantro.Instructions.None;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.InstuctionTypes
{
    [AstNode("INSTR_NONE")]
    public class INSTR_NONEAstNode : AstNodeBase
    {
        public CilInstructionNone Instruction { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // ___("ldarg.0")
            var ldarg0Children = AstChildren.Empty()
                .Add("ldarg.0");
            if (ldarg0Children.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // _("ret")
            var retChildren = AstChildren.Empty()
                .Add("ret");
            if (retChildren.PopulateWith(parseNode))
            {
                Instruction = new ReturnInstruction();

                return;
            }

            // ___("ldc.i4.0")
            var ldci40Children = AstChildren.Empty()
                .Add("ldc.i4.0");
            if (ldci40Children.PopulateWith(parseNode))
            {
                Instruction = new LoadConstI40Instruction();

                return;
            }

            // ___("ldc.i4.1")
            var ldci41Children = AstChildren.Empty()
                .Add("ldc.i4.1");
            if (ldci41Children.PopulateWith(parseNode))
            {
                Instruction = new LoadConstI41Instruction();

                return;
            }

            // ___("ldc.i4.2")
            var ldci42Children = AstChildren.Empty()
                .Add("ldc.i4.2");
            if (ldci42Children.PopulateWith(parseNode))
            {
                Instruction = new LoadConstI42Instruction();

                return;
            }

            // ___("ldc.i4.3")
            var ldci43Children = AstChildren.Empty()
                .Add("ldc.i4.3");
            if (ldci43Children.PopulateWith(parseNode))
            {
                Instruction = new LoadConstI43Instruction();

                return;
            }

            // ___("ldc.i4.4")
            var ldci44Children = AstChildren.Empty()
                .Add("ldc.i4.4");
            if (ldci44Children.PopulateWith(parseNode))
            {
                Instruction = new LoadConstI44Instruction();

                return;
            }

            // ___("ldc.i4.5")
            var ldci45Children = AstChildren.Empty()
                .Add("ldc.i4.5");
            if (ldci45Children.PopulateWith(parseNode))
            {
                Instruction = new LoadConstI45Instruction();

                return;
            }

            // ___("ldc.i4.6")
            var ldci46Children = AstChildren.Empty()
                .Add("ldc.i4.6");
            if (ldci46Children.PopulateWith(parseNode))
            {
                Instruction = new LoadConstI46Instruction();

                return;
            }

            // ___("ldc.i4.7")
            var ldci47Children = AstChildren.Empty()
                .Add("ldc.i4.7");
            if (ldci47Children.PopulateWith(parseNode))
            {
                Instruction = new LoadConstI47Instruction();

                return;
            }

            // ___("ldc.i4.8")
            var ldci48Children = AstChildren.Empty()
                .Add("ldc.i4.8");
            if (ldci48Children.PopulateWith(parseNode))
            {
                Instruction = new LoadConstI48Instruction();

                return;
            }

            // ___("ldc.i4.m1")
            var ldci4m1Children = AstChildren.Empty()
                .Add("ldc.i4.m1");
            if (ldci4m1Children.PopulateWith(parseNode))
            {
                Instruction = new LoadConstI4M1Instruction();

                return;
            }

            // ___("ldc.i4.M1")
            var ldci4M1Children = AstChildren.Empty()
                .Add("ldc.i4.M1");
            if (ldci4M1Children.PopulateWith(parseNode))
            {
                Instruction = new LoadConstI4M1Instruction();

                return;
            }

            // _("dup")
            var dupChildren = AstChildren.Empty()
                .Add("dup");
            if (dupChildren.PopulateWith(parseNode))
            {
                Instruction = new DuplicateInstruction();

                return;
            }

            // ___("stelem.i2")
            var stelemi2Children = AstChildren.Empty()
                .Add("stelem.i2");
            if (stelemi2Children.PopulateWith(parseNode))
            {
                Instruction = new StoreArrayElementI2Instruction();

                return;
            }

            // ___("ldelem.ref")
            var ldelemrefChildren = AstChildren.Empty()
                .Add("ldelem.ref");
            if (ldelemrefChildren.PopulateWith(parseNode))
            {
                Instruction = new LoadArrayElementRefInstruction();

                return;
            }

            // ___("stloc.0")
            var stloc0Children = AstChildren.Empty()
                .Add("stloc.0");
            if (stloc0Children.PopulateWith(parseNode))
            {
                Instruction = new StoreLocal0Instruction();

                return;
            }

            // ___("stloc.1")
            var stloc1Children = AstChildren.Empty()
                .Add("stloc.1");
            if (stloc1Children.PopulateWith(parseNode))
            {
                Instruction = new StoreLocal1Instruction();

                return;
            }

            // ___("ldloc.0")
            var ldloc0Children = AstChildren.Empty()
                .Add("ldloc.0");
            if (ldloc0Children.PopulateWith(parseNode))
            {
                Instruction = new LoadLocal0Instruction();

                return;
            }

            // ___("ldloc.1")
            var ldloc1Children = AstChildren.Empty()
                .Add("ldloc.1");
            if (ldloc1Children.PopulateWith(parseNode))
            {
                Instruction = new LoadLocal1Instruction();

                return;
            }

            // _("add")
            var addChildren = AstChildren.Empty()
                .Add("add");
            if (addChildren.PopulateWith(parseNode))
            {
                Instruction = new AddInstruction();

                return;
            }

            throw new NotImplementedException();
        }
    }
}