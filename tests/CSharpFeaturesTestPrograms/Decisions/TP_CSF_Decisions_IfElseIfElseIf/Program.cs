using System;

namespace TP_CSF_Decisions_IfElseIfElseIf
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            if (n % 3 == 0) Console.WriteLine("zero");
            else if (n % 3 == 1) Console.WriteLine("one");
            else if (n % 3 == 2) Console.WriteLine("two");
        }
    }
}