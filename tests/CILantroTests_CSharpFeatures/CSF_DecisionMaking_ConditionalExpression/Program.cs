using System;

namespace CSF_DecisionMaking_ConditionalExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split(' ');

            var a = int.Parse(line[0]);
            var b = int.Parse(line[1]);

            var min = a <= b ? a : b;
            var max = a >= b ? a : b;

            Console.Write(min);
            Console.Write(" ");
            Console.WriteLine(max);
        }
    }
}