using System;

namespace TP_CSF_Operators_LogicalOperators_Not
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = bool.Parse(Console.ReadLine());
            var result = !b;
            Console.WriteLine(result);
        }
    }
}