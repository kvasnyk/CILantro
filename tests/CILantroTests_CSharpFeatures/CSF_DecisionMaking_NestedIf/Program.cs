using System;

namespace CSF_DecisionMaking_NestedIf
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            if (n < 0)
            {
                if (n % 2 == 0)
                    Console.WriteLine("NEGATIVE EVEN");
                else
                    Console.WriteLine("NEGATIVE ODD");
            }
            else if (n == 0)
            {
                if (n % 2 == 0)
                    Console.WriteLine("ZERO EVEN");
                else
                    Console.WriteLine("ZERO ODD");
            }
            else
            {
                if (n % 2 == 0)
                    Console.WriteLine("POSITIVE EVEN");
                else
                    Console.WriteLine("POSITIVE ODD");
            }
        }
    }
}