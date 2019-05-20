using System;

namespace TP_CSF_Decisions_IfElseIfElse
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            if (n < 0) Console.WriteLine("negative");
            else if (n == 0) Console.WriteLine("zero");
            else Console.WriteLine("positive");
        }
    }
}