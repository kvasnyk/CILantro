using CILantro.Parsing;
using System;

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

        public void Parse()
        {
            Console.WriteLine(_sourceCode);
            _parser.Parse(_sourceCode);
        }
    }
}