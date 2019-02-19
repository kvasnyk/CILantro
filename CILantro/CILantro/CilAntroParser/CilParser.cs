﻿using CILantro.CilAntroGrammar;
using Irony.Parsing;

namespace CILantro.CilAntroParser
{
    public class CilParser
    {
        private readonly Parser _ironyParser;

        public CilParser()
        {
            _ironyParser = new Parser(new CilGrammar());
        }

        public void Parse(string sourceCode)
        {
            _ironyParser.Parse(sourceCode);
        }
    }
}