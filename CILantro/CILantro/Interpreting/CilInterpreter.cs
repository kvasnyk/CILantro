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
            var interpreterVisitor = new CilInterpreterInstructionsVisitor(_program);
            interpreterVisitor.Visit();
        }
    }
}