using System;

namespace TP_CSF_Operators_LogicalOperators_And
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = bool.Parse(Console.ReadLine());
            var b = bool.Parse(Console.ReadLine());

            var result = a && b;
            Console.WriteLine(result);
        }
    }
}