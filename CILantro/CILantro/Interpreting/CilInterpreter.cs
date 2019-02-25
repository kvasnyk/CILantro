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
            var state = new CilControlState(_program.EntryPoint);

            while (state.CurrentInstruction != null)
            {
                state.CurrentInstruction.Execute(state);
            }

            return;
        }
    }
}
