using CILantro.ConsoleClient;
using CILantro.Engine;
using System;

namespace CILantro
{
    class Program
    {
        static void Main(string[] originalArgs)
        {
            var args = CILantroArgs.Parse(originalArgs);
            Console.WriteLine(args.FileName);

            var engine = new CilEngine("test");
            engine.Parse();
        }
    }
}