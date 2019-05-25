using CILantro.Exceptions;
using CILantro.Interpreting.Visitors;
using CILantro.Structure;

namespace CILantro.Interpreting
{
    public class CilInterpreter
    {
        private readonly CilProgram _program;

        public CilInterpreter(CilProgram program)
        {
            _program = program;
        }

        public void Interpret()
        {
            if (!CheckSupported(_program))
                return;

            var interpreterVisitor = new CilInterpreterInstructionsVisitor(_program);
            interpreterVisitor.Visit();
        }

        private bool CheckSupported(CilProgram program)
        {
            foreach (var method in program.AllMethods)
            {
                foreach (var instruction in method.Instructions)
                {
                    if (!instruction.IsSupported)
                        throw new InstructionNotSupportedException(instruction);
                }
            }

            if (program.Datas.Count > 0)
                throw new FeatureNotSupportedException(".data");

            return true;
        }
    }
}