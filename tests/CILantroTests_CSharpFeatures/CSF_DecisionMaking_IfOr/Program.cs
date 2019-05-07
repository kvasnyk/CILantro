using System;

namespace CSF_DecisionMaking_IfOr
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = bool.Parse(Console.ReadLine());
            var b = bool.Parse(Console.ReadLine());

            if (a || b)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}