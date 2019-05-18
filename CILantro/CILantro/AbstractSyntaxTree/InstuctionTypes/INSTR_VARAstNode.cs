using CILantro.Instructions;
using CILantro.Instructions.Var;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.InstuctionTypes
{
    [AstNode("INSTR_VAR")]
    public class INSTR_VARAstNode : AstNodeBase
    {
        public CilInstructionVar Instruction { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // ___("stloc.s")
            var stlocsChildren = AstChildren.Empty()
                .Add("stloc.s");
            if (stlocsChildren.PopulateWith(parseNode))
            {
                Instruction = new StoreLocalShortInstruction();

                return;
            }

            // ___("ldloc.s")
            var ldlocsChildren = AstChildren.Empty()
                .Add("ldloc.s");
            if (ldlocsChildren.PopulateWith(parseNode))
            {
                Instruction = new LoadLocalShortInstruction();

                return;
            }

            // ___("ldloca.s")
            var ldlocasChildren = AstChildren.Empty()
                .Add("ldloca.s");
            if (ldlocasChildren.PopulateWith(parseNode))
            {
                Instruction = new LoadLocalAddressShortInstruction();

                return;
            }

            // ___("ldarg.s")
            var ldargsChildren = AstChildren.Empty()
                .Add("ldarg.s");
            if (ldargsChildren.PopulateWith(parseNode))
            {
                Instruction = new LoadArgumentShortInstruction();

                return;
            }

            throw new NotImplementedException();
        }
    }
}