using CILantro.Instructions;
using System;

namespace CILantro.Visitors
{
    public abstract class CilInstructionsVisitor
    {
        protected abstract InstructionNoneVisitor InstructionNoneVisitor { get; }

        protected abstract InstructionMethodVisitor InstructionMethodVisitor { get; }

        protected abstract InstructionStringVisitor InstructionStringVisitor { get; }

        public void Visit()
        {
            var nextInstruction = GetNextInstruction();
            while (nextInstruction != null)
            {
                VisitInstruction(nextInstruction);
                nextInstruction = GetNextInstruction();
            }
        }

        protected abstract CilInstruction GetNextInstruction();

        private void VisitInstruction(CilInstruction instruction)
        {
            if (instruction is CilInstructionNone instructionNone)
                InstructionNoneVisitor.VisitInstructionNone(instructionNone);
            else if (instruction is CilInstructionMethod instructionMethod)
                InstructionMethodVisitor.VisitInstructionMethod(instructionMethod);
            else if (instruction is CilInstructionString instructionString)
                InstructionStringVisitor.VisitInstructionString(instructionString);
            else
                throw new ArgumentException($"CIL instruction cannot be recognized: '{instruction.ToString()}'.");
        }
    }
}