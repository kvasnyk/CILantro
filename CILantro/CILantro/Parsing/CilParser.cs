﻿
using CILantro.AbstractSyntaxTree.Other;
using CILantro.Structure;
using Irony;
using Irony.Parsing;
using System.Linq;

namespace CILantro.Parsing
{
    public class CilParser
    {
        private readonly Parser _ironyParser;

        public CilParser()
        {
            _ironyParser = new Parser(new CilGrammar());
        }

        public CilParserResult Parse(string sourceCode)
        {
            var ironyParseTree = _ironyParser.Parse(sourceCode);

            if (ironyParseTree.Status == ParseTreeStatus.Error)
            {
                return new CilParserResult
                {
                    Status = CilParserStatus.ParsingError,
                    Errors = ironyParseTree.ParserMessages.Select(pm => BuildIronyParserMessage(pm)).ToList()
                };
            }

            var decls = (ironyParseTree.Root.AstNode as DeclsAstNode).Decls;
            var cilProgram = new CilProgram(decls);

            return new CilParserResult
            {
                Status = CilParserStatus.Success,
                Program = cilProgram
            };
        }

        private string BuildIronyParserMessage(LogMessage ironyMessage)
        {
            var errorLocation = ironyMessage.Location;
            var locationString = $"ln {errorLocation.Line + 1}, ch {errorLocation.Column + 1}";

            return $"{locationString}: {ironyMessage.Message}";
        }
    }
}