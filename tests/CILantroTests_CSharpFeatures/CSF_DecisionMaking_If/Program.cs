using System;

namespace CSF_DecisionMaking_If
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            if (n < 0)
                Console.WriteLine("NEGATIVE");
            else
                Console.WriteLine("NON-NEGATIVE");
        }
    }
}