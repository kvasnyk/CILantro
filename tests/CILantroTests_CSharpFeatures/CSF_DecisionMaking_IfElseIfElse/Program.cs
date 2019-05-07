using System;

namespace CSF_DecisionMaking_IfElseIfElse
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            if (n < 0)
                Console.WriteLine("NEGATIVE");
            else if (n == 0)
                Console.WriteLine("ZERO");
            else
                Console.WriteLine("POSITIVE");
        }
    }
}