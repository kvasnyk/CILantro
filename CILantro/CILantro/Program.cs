using CILantro.ConsoleClient;
using CILantro.Engine;
using CILantro.Parsing;
using System;
using System.IO;

namespace CILantro
{
    class Program
    {
        static void Main(string[] originalArgs)
        {
            var args = CILantroArgs.Parse(originalArgs);

            var ilSourceCode = File.ReadAllText(args.FileName);

            var engine = new CilEngine(ilSourceCode);
            var parserResult = engine.Parse();

            if (parserResult.Status == CilParserStatus.ParsingError)
            {
                foreach (var error in parserResult.Errors)
                {
                    Console.Error.WriteLine(error);
                }

                return;
            }

            engine.Interpret(parserResult.Program);
        }
    }
}