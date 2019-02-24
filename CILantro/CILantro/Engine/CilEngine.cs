using CILantro.Interpreting;
using CILantro.Parsing;
using CILantro.Structure;

namespace CILantro.Engine
{
    public class CilEngine
    {
        private readonly CilParser _parser;

        private readonly string _sourceCode;

        public CilEngine(string sourceCode)
        {
            _parser = new CilParser();

            _sourceCode = sourceCode;
        }

        public CilParserResult Parse()
        {
            return _parser.Parse(_sourceCode);
        }

        public void Interpret(CilProgram program)
        {
            var interpreter = new CilInterpreter(program);
            interpreter.Interpret();
        }
    }
}