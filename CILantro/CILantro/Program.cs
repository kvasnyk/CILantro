using CILantro.CilAntroParser;
using System;

namespace CILantro
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new CilParser();
            parser.Parse("test");

            Console.WriteLine("CILantro!");
        }
    }
}
