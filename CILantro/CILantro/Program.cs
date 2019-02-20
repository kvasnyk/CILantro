using CILantro.ConsoleClient;
using CILantro.Engine;
using System;
using System.IO;

namespace CILantro
{
    class Program
    {
        static void Main(string[] originalArgs)
        {
            var args = CILantroArgs.Parse(originalArgs);
            Console.WriteLine(args.FileName);

            var ilSourceCode = File.ReadAllText(args.FileName);

            var engine = new CilEngine(ilSourceCode);
            engine.Parse();
        }
    }
}