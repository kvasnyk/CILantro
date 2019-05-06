using System;

namespace CSF_DecisionMaking_IfTrue2
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = bool.Parse(Console.ReadLine());

            if (b == false)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}