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

            // ___("stloc.2")
            var stloc2Children = AstChildren.Empty()
                .Add("stloc.2");
            if (stloc2Children.PopulateWith(parseNode))
            {
                Instruction = new StoreLocal2Instruction();

                return;
            }

            // ___("stloc.3")
            var stloc3Children = AstChildren.Empty()
                .Add("stloc.3");
            if (stloc3Children.PopulateWith(parseNode))
            {
                Instruction = new StoreLocal3Instruction();

                return;
            }

            // ___("ldloc.2")
            var ldloc2Children = AstChildren.Empty()
                .Add("ldloc.2");
            if (ldloc2Children.PopulateWith(parseNode))
            {
                Instruction = new LoadLocal2Instruction();

                return;
            }

            // ___("conv.i8")
            var convi8Children = AstChildren.Empty()
                .Add("conv.i8");
            if (convi8Children.PopulateWith(parseNode))
            {
                Instruction = new ConvertI8Instruction();

                return;
            }

            // ___("ldloc.3")
            var ldloc3Children = AstChildren.Empty()
                .Add("ldloc.3");
            if (ldloc3Children.PopulateWith(parseNode))
            {
                Instruction = new LoadLocal3Instruction();

                return;
            }

            // ___("conv.u8")
            var convu8Children = AstChildren.Empty()
                .Add("conv.u8");
            if (convu8Children.PopulateWith(parseNode))
            {
                Instruction = new ConvertU8Instruction();

                return;
            }

            // ___("conv.r4")
            var convr4Children = AstChildren.Empty()
                .Add("conv.r4");
            if (convr4Children.PopulateWith(parseNode))
            {
                Instruction = new ConvertR4Instruction();

                return;
            }

            // ___("conv.r8")
            var convr8Children = AstChildren.Empty()
                .Add("conv.r8");
            if (convr8Children.PopulateWith(parseNode))
            {
                Instruction = new ConvertR8Instruction();

                return;
            }

            // ___("conv.r.un")
            var convrunChildren = AstChildren.Empty()
                .Add("conv.r.un");
            if (convrunChildren.PopulateWith(parseNode))
            {
                Instruction = new ConvertRUnsignedInstruction();

                return;
            }

            // _("sub")
            var subChildren = AstChildren.Empty()
                .Add("sub");
            if (subChildren.PopulateWith(parseNode))
            {
                Instruction = new SubtractInstruction();

                return;
            }

            // ___("conv.i1")
            var convi1Children = AstChildren.Empty()
                .Add("conv.i1");
            if (convi1Children.PopulateWith(parseNode))
            {
                Instruction = new ConvertI1Instruction();

                return;
            }

            // ___("conv.i2")
            var convi2Children = AstChildren.Empty()
                .Add("conv.i2");
            if (convi2Children.PopulateWith(parseNode))
            {
                Instruction = new ConvertI2Instruction();

                return;
            }

            // ___("conv.u1")
            var convu1Children = AstChildren.Empty()
                .Add("conv.u1");
            if (convu1Children.PopulateWith(parseNode))
            {
                Instruction = new ConvertU1Instruction();

                return;
            }

            // ___("conv.u2")
            var convu2Children = AstChildren.Empty()
                .Add("conv.u2");
            if(convu2Children.PopulateWith(parseNode))
            {
                Instruction = new ConvertU2Instruction();

                return;
            }

            // _("mul")
            var mulChildren = AstChildren.Empty()
                .Add("mul");
            if (mulChildren.PopulateWith(parseNode))
            {
                Instruction = new MultiplyInstruction();

                return;
            }

            // _("div")
            var divChildren = AstChildren.Empty()
                .Add("div");
            if (divChildren.PopulateWith(parseNode))
            {
                Instruction = new DivideInstruction();

                return;
            }

            // ___("div.un")
            var divunChildren = AstChildren.Empty()
                .Add("div.un");
            if (divunChildren.PopulateWith(parseNode))
            {
                Instruction = new DivideUnsignedInstruction();

                return;
            }

            // _("rem")
            var remChildren = AstChildren.Empty()
                .Add("rem");
            if (remChildren.PopulateWith(parseNode))
            {
                Instruction = new RemainderInstruction();

                return;
            }

            // ___("rem.un")
            var remunChildren = AstChildren.Empty()
                .Add("rem.un");
            if (remunChildren.PopulateWith(parseNode))
            {
                Instruction = new RemainderUnsignedInstruction();

                return;
            }

            // _("ceq")
            var ceqChildren = AstChildren.Empty()
                .Add("ceq");
            if (ceqChildren.PopulateWith(parseNode))
            {
                Instruction = new CompareEqualInstruction();

                return;
            }

            // _("cgt")
            var cgtChildren = AstChildren.Empty()
                .Add("cgt");
            if (cgtChildren.PopulateWith(parseNode))
            {
                Instruction = new CompareGreaterThanInstruction();

                return;
            }

            // ___("cgt.un")
            var cgtunChildren = AstChildren.Empty()
                .Add("cgt.un");
            if (cgtunChildren.PopulateWith(parseNode))
            {
                Instruction = new CompareGreaterThanUnsignedInstruction();

                return;
            }

            // _("clt")
            var cltChildren = AstChildren.Empty()
                .Add("clt");
            if (cltChildren.PopulateWith(parseNode))
            {
                Instruction = new CompareLessThanInstruction();

                return;
            }

            // ___("clt.un")
            var cltunChildren = AstChildren.Empty()
                .Add("clt.un");
            if (cltunChildren.PopulateWith(parseNode))
            {
                Instruction = new CompareLessThanUnsignedInstruction();

                return;
            }

            // _("and")
            var andChildren = AstChildren.Empty()
                .Add("and");
            if (andChildren.PopulateWith(parseNode))
            {
                Instruction = new AndInstruction();

                return;
            }

            // _("or")
            var orChildren = AstChildren.Empty()
                .Add("or");
            if (orChildren.PopulateWith(parseNode))
            {
                Instruction = new OrInstruction();

                return;
            }

            // _("pop")
            var popChildren = AstChildren.Empty()
                .Add("pop");
            if (popChildren.PopulateWith(parseNode))
            {
                Instruction = new PopInstruction();

                return;
            }

            // _("xor")
            var xorChildren = AstChildren.Empty()
                .Add("xor");
            if (xorChildren.PopulateWith(parseNode))
            {
                Instruction = new XorInstruction();

                return;
            }

            // _("shl")
            var shlChildren = AstChildren.Empty()
                .Add("shl");
            if (shlChildren.PopulateWith(parseNode))
            {
                Instruction = new ShiftLeftInstruction();

                return;
            }

            // _("shr")
            var shrChildren = AstChildren.Empty()
                .Add("shr");
            if (shrChildren.PopulateWith(parseNode))
            {
                Instruction = new ShiftRightInstruction();

                return;
            }

            // ___("shr.un")
            var shrunChildren = AstChildren.Empty()
                .Add("shr.un");
            if (shrunChildren.PopulateWith(parseNode))
            {
                Instruction = new ShiftRightUnsignedInstruction();

                return;
            }

            // _("not")
            var notChildren = AstChildren.Empty()
                .Add("not");
            if (notChildren.PopulateWith(parseNode))
            {
                Instruction = new NotInstruction();

                return;
            }

            // _("neg")
            var negChildren = AstChildren.Empty()
                .Add("neg");
            if (negChildren.PopulateWith(parseNode))
            {
                Instruction = new NegateInstruction();

                return;
            }

            throw new NotImplementedException();
        }
    }
}